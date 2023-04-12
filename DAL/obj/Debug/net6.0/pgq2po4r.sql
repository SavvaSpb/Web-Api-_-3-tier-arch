IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Institute] (
    [institute_id] int NOT NULL IDENTITY,
    [institute_type_name] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Institute] PRIMARY KEY ([institute_id])
);
GO

CREATE TABLE [Student] (
    [student_id] int NOT NULL IDENTITY,
    [first_name] nvarchar(max) NOT NULL,
    [last_name] nvarchar(max) NOT NULL,
    [birthday] datetime2 NULL,
    [address] nvarchar(max) NULL,
    [phone] nvarchar(max) NULL,
    [email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Student] PRIMARY KEY ([student_id])
);
GO

CREATE TABLE [Teacher] (
    [teacher_id] int NOT NULL IDENTITY,
    [first_name] nvarchar(max) NOT NULL,
    [last_name] nvarchar(max) NOT NULL,
    [birthday] datetime2 NULL,
    [address] nvarchar(max) NULL,
    [phone] nvarchar(max) NULL,
    [email] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Teacher] PRIMARY KEY ([teacher_id])
);
GO

CREATE TABLE [Course] (
    [course_id] int NOT NULL IDENTITY,
    [course_type_name] nvarchar(max) NOT NULL,
    [institute_id] int NOT NULL,
    [teacher_id] int NOT NULL,
    [salary] int NOT NULL,
    CONSTRAINT [PK_Course] PRIMARY KEY ([course_id]),
    CONSTRAINT [FK_Course_Institute_institute_id] FOREIGN KEY ([institute_id]) REFERENCES [Institute] ([institute_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Course_Teacher_teacher_id] FOREIGN KEY ([teacher_id]) REFERENCES [Teacher] ([teacher_id]) ON DELETE CASCADE
);
GO

CREATE TABLE [StudentCourse] (
    [student_course_id] int NOT NULL IDENTITY,
    [student_id] int NOT NULL,
    [course_id] int NOT NULL,
    [student_grade] int NOT NULL,
    CONSTRAINT [PK_StudentCourse] PRIMARY KEY ([student_course_id]),
    CONSTRAINT [FK_StudentCourse_Course_course_id] FOREIGN KEY ([course_id]) REFERENCES [Course] ([course_id]) ON DELETE CASCADE,
    CONSTRAINT [FK_StudentCourse_Student_student_id] FOREIGN KEY ([student_id]) REFERENCES [Student] ([student_id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Course_institute_id] ON [Course] ([institute_id]);
GO

CREATE INDEX [IX_Course_teacher_id] ON [Course] ([teacher_id]);
GO

CREATE INDEX [IX_StudentCourse_course_id] ON [StudentCourse] ([course_id]);
GO

CREATE INDEX [IX_StudentCourse_student_id] ON [StudentCourse] ([student_id]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230228095948_Init', N'7.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [UserAccount] (
    [user_account_id] int NOT NULL IDENTITY,
    [email] nvarchar(max) NOT NULL,
    [password] nvarchar(max) NULL,
    [phone] nvarchar(max) NULL,
    CONSTRAINT [PK_UserAccount] PRIMARY KEY ([user_account_id])
);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230314091742_UserAccount', N'7.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

DECLARE @var0 sysname;
SELECT @var0 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserAccount]') AND [c].[name] = N'email');
IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [UserAccount] DROP CONSTRAINT [' + @var0 + '];');
ALTER TABLE [UserAccount] ALTER COLUMN [email] nvarchar(450) NOT NULL;
GO

DECLARE @var1 sysname;
SELECT @var1 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teacher]') AND [c].[name] = N'email');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Teacher] DROP CONSTRAINT [' + @var1 + '];');
ALTER TABLE [Teacher] ALTER COLUMN [email] nvarchar(450) NOT NULL;
GO

CREATE UNIQUE INDEX [IX_UserAccount_email] ON [UserAccount] ([email]);
GO

CREATE UNIQUE INDEX [IX_Teacher_email] ON [Teacher] ([email]);
GO

ALTER TABLE [Teacher] ADD CONSTRAINT [Phone] CHECK (Phone like '+374%');
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230404123313_Test_Constraints', N'7.0.3');
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

ALTER TABLE [Course] ADD CONSTRAINT [Salary] CHECK (Salary > 50 );
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230405125006_ConstraintOnCourseSalary', N'7.0.3');
GO

COMMIT;
GO

