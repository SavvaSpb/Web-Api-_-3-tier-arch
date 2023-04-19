BEGIN TRANSACTION;
GO

ALTER TABLE [Course] ADD CONSTRAINT [Salary] CHECK (Salary > 50 );
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20230405125006_ConstraintOnCourseSalary', N'7.0.3');
GO

COMMIT;
GO

