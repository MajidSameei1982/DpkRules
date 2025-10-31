# DpkRules
### 1. جدول قوانین (Rules)

| Column Name       | Type         | Description                                 |
|-------------------|--------------|---------------------------------------------|
| RuleId            | VARCHAR(50)  | شناسه یکتا برای قانون                      |
| Description       | TEXT         | توضیح قانون                                 |
| EntityType        | VARCHAR(50)  | نوع موجودیت (مثلاً Collateral, Guarantor) |
| EffectiveDate     | DATETIME     | تاریخ شروع اعتبار قانون                    |
| ExpiryDate        | DATETIME     | تاریخ پایان اعتبار                         |
| IsActive          | BIT          | فعال بودن قانون                             |

### 2. جدول شرایط قانون (RuleConditions)

| Column Name   | Type         | Description                          |
|---------------|--------------|--------------------------------------|
| ConditionId   | INT          | شناسه شرط                            |
| RuleId        | VARCHAR(50)  | ارتباط با جدول Rules                |
| Field         | VARCHAR(50)  | نام فیلد                              |
| Operator      | VARCHAR(20)  | عملگر (GreaterThan, Equals, ...)     |
| Value         | VARCHAR(100) | مقدار شرط                            |

### 3. جدول الزامات قانون (RuleRequirements)

| Column Name   | Type         | Description                          |
|---------------|--------------|--------------------------------------|
| RequirementId | INT          | شناسه الزام                          |
| RuleId        | VARCHAR(50)  | ارتباط با جدول Rules                |
| FieldName     | VARCHAR(50)  | نام فیلد الزامی                      |

### 4. جدول تاریخچه تغییرات قوانین (RuleHistory)

| Column Name   | Type         | Description                          |
|---------------|--------------|--------------------------------------|
| HistoryId     | INT          | شناسه تاریخچه                        |
| RuleId        | VARCHAR(50)  | ارتباط با قانون                      |
| ChangeType    | VARCHAR(50)  | نوع تغییر (افزایش سقف، تنفیذ، ...)  |
| ChangedBy     | VARCHAR(50)  | نام کاربر یا سیستم                   |
| ChangeDate    | DATETIME     | زمان تغییر                           |
| OldValue      | TEXT         | مقدار قبلی                           |
| NewValue      | TEXT         | مقدار جدید                           |
