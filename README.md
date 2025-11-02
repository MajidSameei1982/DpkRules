# DpkRules

### Metadata-Driven

این معماری به شما اجازه می‌دهد بدون تغییر کد، موارد جدید را از طریق پنل ادمین یا فایل‌های پیکربندی اضافه کنید.

### طراحی جداول دیتابیس برای موجودیت‌های قابل تعریف

####  جدول ContractTypes (نوع عقد)

| ContractTypeId | Name      | IsActive | Description         |
|----------------|-----------|----------|---------------------|
| 1              | مرابحه     | true     | عقد فروش با سود مشخص |
| 2              | جعاله      | true     | عقد خدماتی           |

####  جدول SubContractTypes (زیرنوع عقد)

| SubTypeId | ContractTypeId | Name       | IsActive | Description         |
|-----------|----------------|------------|----------|---------------------|
| 1         | 1              | طرح         | true     | مرابحه طرحی         |
| 2         | 1              | اقساطی      | true     | مرابحه اقساطی       |

####  جدول CreditRatings (رتبه‌بندی اعتباری)

| RatingId | Grade | MinScore | MaxScore | ValidityMonths |
|----------|-------|----------|----------|----------------|
| 1        | A     | 800      | 1000     | 12             |
| 2        | B     | 600      | 799      | 12             |

####  جدول CollateralTypes (نوع وثیقه)

| CollateralTypeId | Name     | CoveragePercent | IsActive |
|------------------|----------|------------------|----------|
| 1                | ملکی     | 150              | true     |
| 2                | چک       | 120              | true     |

####  جدول GuarantorTypes (نوع ضامن)

| GuarantorTypeId | Name       | IsLegalEntity | IsActive |
|-----------------|------------|---------------|----------|
| 1               | شخص حقیقی  | false         | true     |
| 2               | شرکت حقوقی | true          | true     |

###  جدول قوانین (Rules)

| Column Name       | Type         | Description                                 |
|-------------------|--------------|---------------------------------------------|
| RuleId            | VARCHAR(50)  | شناسه یکتا برای قانون                      |
| Description       | TEXT         | توضیح قانون                                 |
| EntityType        | VARCHAR(50)  | نوع موجودیت (مثلاً Collateral, Guarantor) |
| EffectiveDate     | DATETIME     | تاریخ شروع اعتبار قانون                    |
| ExpiryDate        | DATETIME     | تاریخ پایان اعتبار                         |
| IsActive          | BIT          | فعال بودن قانون                             |

###  جدول شرایط قانون (RuleConditions)

| Column Name   | Type         | Description                          |
|---------------|--------------|--------------------------------------|
| ConditionId   | INT          | شناسه شرط                            |
| RuleId        | VARCHAR(50)  | ارتباط با جدول Rules                |
| Field         | VARCHAR(50)  | نام فیلد                              |
| Operator      | VARCHAR(20)  | عملگر (GreaterThan, Equals, ...)     |
| Value         | VARCHAR(100) | مقدار شرط                            |

###  جدول الزامات قانون (RuleRequirements)

| Column Name   | Type         | Description                          |
|---------------|--------------|--------------------------------------|
| RequirementId | INT          | شناسه الزام                          |
| RuleId        | VARCHAR(50)  | ارتباط با جدول Rules                |
| FieldName     | VARCHAR(50)  | نام فیلد الزامی                      |

###  جدول تاریخچه تغییرات قوانین (RuleHistory)

| Column Name   | Type         | Description                          |
|---------------|--------------|--------------------------------------|
| HistoryId     | INT          | شناسه تاریخچه                        |
| RuleId        | VARCHAR(50)  | ارتباط با قانون                      |
| ChangeType    | VARCHAR(50)  | نوع تغییر (افزایش سقف، تنفیذ، ...)  |
| ChangedBy     | VARCHAR(50)  | نام کاربر یا سیستم                   |
| ChangeDate    | DATETIME     | زمان تغییر                           |
| OldValue      | TEXT         | مقدار قبلی                           |
| NewValue      | TEXT         | مقدار جدید                           |

---

### استفاده در فرم‌ها و Rule Engine

- فرم‌ها به صورت داینامیک از این جداول مقداردهی می‌شوند.
- Rule Engine می‌تواند بر اساس مقادیر این جداول اعتبارسنجی انجام دهد.
- در صورت تغییر یا افزودن نوع جدید، فقط داده‌ها تغییر می‌کنند، نه کد.

---

###  مزایای این طراحی

- افزودن موارد جدید بدون تغییر کد
- مدیریت کامل از طریق پنل ادمین یا API
- هماهنگی کامل با Rule Engine و فرم‌ساز

---