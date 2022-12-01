/*
SELECT * FROM Contacts
--WHERE Id = 'F005FC43-8A45-44F9-B70C-822495A72244'

INSERT INTO Contacts VALUES ('F005FC43-8A45-44F9-B70C-822495A72247', 'Per', 'per@mail.com', null)

INSERT INTO Contacts (Id, FirstName, Email) VALUES ('F005FC43-8A45-44F9-B70C-822495A72248', 'Ole', 'ole@mail.com')

UPDATE Contacts SET FirstName = 'Tarje' WHERE Id = 'F005FC43-8A45-44F9-B70C-822495A72244'

DELETE FROM Contacts WHERE Id = 'F005FC43-8A45-44F9-B70C-822495A72244' 
 */

using System.Data.SqlClient;
using Dapper;
using DbIntro;

var connStr = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=Contacts;Integrated Security=True";
var conn = new SqlConnection(connStr);
var sql = "SELECT * FROM Contacts";
var sql2 = @"SELECT con.Id, con.FirstName, con.Email, com.Name
FROM Contacts con LEFT JOIN Company com ON con.Company = com.Id";
var contacts = conn.Query<Person>(sql);
foreach (var contact in contacts)
{
    Console.WriteLine(contact.FirstName + " " + contact.Email);
}