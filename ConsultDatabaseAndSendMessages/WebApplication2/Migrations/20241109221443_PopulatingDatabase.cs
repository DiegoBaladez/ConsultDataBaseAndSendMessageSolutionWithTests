using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseApi.Migrations
{
    /// <inheritdoc />
    public partial class PopulatingDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserir dados na tabela People
            migrationBuilder.InsertData(
                table: "People",
                columns: new[] { "Id", "Name", "Document", "PeopleType", "CustomerNumber", "IsActive" },
                values: new object[,]
                {
                    { 1, "John Doe", "12345678900", "People", 1234, false },
                    { 2, "Jane Smith", "98765432100", "People", 5678, false },
                    { 3, "Carlos Souza", "11223344556", "Customer", 7890, true },
                    { 4, "Maria Oliveira", "66554433221", "Customer", 248758427, false },
                    { 5, "Lucia Ferreira", "99887766554", "Customer", 0248572407, true }
                });

            // Inserir dados na tabela Account
            migrationBuilder.InsertData(
                table: "Account",
                columns: new[] { "Id", "Type", "AccountNumber", "AccountDigit", "CustomerNumber" },
                values: new object[,]
                {
                    { 1, "Savings", 123456789L, 0, 1 },
                    { 2, "Checking", 987654321L, 1, 2 },
                    { 3, "Savings", 135792468L, 2, 3 },
                    { 4, "Checking", 246813579L, 3, 4 },
                    { 5, "Savings", 112233445L, 4, 5 }
                });

            // Inserir dados na tabela Address
            migrationBuilder.InsertData(
                table: "Address",
                columns: new[] { "Id", "Street", "CEP", "City", "Uf", "Number", "Floor", "OfficeNumber", "PeopleId" },
                values: new object[,]
                {
                    { 1, "Rua A", 123456789L, "São Paulo", 1, 123, 1, 101, 1 },
                    { 2, "Rua B", 987654321L, "Rio de Janeiro", 2, 456, 2, 102, 2 },
                    { 3, "Rua C", 112233445L, "Belo Horizonte", 3, 789, 3, 103, 3 },
                    { 4, "Rua D", 998877665L, "Porto Alegre", 4, 101, 4, 104, 4 },
                    { 5, "Rua E", 556677889L, "Curitiba", 5, 202, 5, 105, 5 }
                });

            // Inserir dados na tabela Telephone
            migrationBuilder.InsertData(
                table: "Telephone",
                columns: new[] { "Id", "DDD", "Number", "Type", "PeopleId" },
                values: new object[,]
                {
                    { 1, 11, 123456789, 1, 1 },
                    { 2, 21, 987654321, 2, 2 },
                    { 3, 31, 135792468, 3, 3 },
                    { 4, 41, 246813579, 1, 4 },
                    { 5, 51, 112233445, 2, 5 }
                });

            migrationBuilder.InsertData(
            table: "Entrys",
            columns: new[] { "Id", "Amount", "Description", "Date", "DebitCreditIndicator", "CustomerNumber" },
            values: new object[,]
            {
                { 1, 1500.50, "Deposit", DateTime.Now, 1, 1 },
                { 2, 500.75, "Withdrawal", DateTime.Now, 0, 1 },
                { 3, 2000.00, "Deposit", DateTime.Now, 1, 1 },
                { 4, 1000.00, "Withdrawal", DateTime.Now, 0, 1 },
                { 5, 2500.00, "Deposit", DateTime.Now, 1, 1 },
                { 6, 1200.50, "Deposit", DateTime.Now, 1, 2 },
                { 7, 600.75, "Withdrawal", DateTime.Now, 0, 2 },
                { 8, 1800.00, "Deposit", DateTime.Now, 1, 2 },
                { 9, 900.00, "Withdrawal", DateTime.Now, 0, 2 },
                { 10, 2200.00, "Deposit", DateTime.Now, 1, 2 },
                { 11, 1500.50, "Deposit", DateTime.Now, 1, 3 },
                { 12, 800.75, "Withdrawal", DateTime.Now, 0, 3 },
                { 13, 2100.00, "Deposit", DateTime.Now, 1, 3 },
                { 14, 1100.00, "Withdrawal", DateTime.Now, 0, 3 },
                { 15, 2600.00, "Deposit", DateTime.Now, 1, 3 },
                { 16, 1300.50, "Deposit", DateTime.Now, 1, 4 },
                { 17, 700.75, "Withdrawal", DateTime.Now, 0, 4 },
                { 18, 1900.00, "Deposit", DateTime.Now, 1, 4 },
                { 19, 950.00, "Withdrawal", DateTime.Now, 0, 4 },
                { 20, 2300.00, "Deposit", DateTime.Now, 1, 4 },
                { 21, 1400.50, "Deposit", DateTime.Now, 1, 5 },
                { 22, 650.75, "Withdrawal", DateTime.Now, 0, 5 },
                { 23, 2000.00, "Deposit", DateTime.Now, 1, 5 },
                { 24, 1050.00, "Withdrawal", DateTime.Now, 0, 5 },
                { 25, 2400.00, "Deposit", DateTime.Now, 1, 5 }
            });


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Entrys",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Telephone",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Address",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "Account",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });

            migrationBuilder.DeleteData(
                table: "People",
                keyColumn: "Id",
                keyValues: new object[] { 1, 2, 3, 4, 5 });
        }
    }
}
