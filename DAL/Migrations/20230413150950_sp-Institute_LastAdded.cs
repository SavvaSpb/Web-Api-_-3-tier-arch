using Microsoft.EntityFrameworkCore.Migrations;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Collections.Generic;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class spInstitute_LastAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            var sp = @"CREATE PROCEDURE[Institute_LastAdded]
                     @institute_type_name varchar(255)
                     AS
                     BEGIN

                       BEGIN TRY

                           INSERT INTO institute
                           (institute_type_name, IsLastAdded)
                           VALUES
                           (@institute_type_name, 1)

                           declare @institute_id INT
                           set @institute_id = scope_identity()

                           UPDATE institute SET IsLastAdded = 0 WHERE institute_id != @institute_id
                       END TRY

                     BEGIN CATCH
                         ROLLBACK TRANSACTION
                     END CATCH

                     END";

            migrationBuilder.Sql(sp);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE [Institute_LastAdded]");
        }
    }
}
