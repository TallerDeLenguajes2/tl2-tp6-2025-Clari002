using Microsoft.Data.Sqlite;
string connectionString = "Data Source=Tienda_final.db;";

// Crear conexión a la base de datos
using (SqliteConnection connection = new SqliteConnection(connectionString))
{
    connection.Open();
    // Crear tabla si no existe
    // por lo general este tipo de consultas no se implementa en un porgrama real
    // la aplicamos para poder crear nuestra base de datos desde cero
    string createTableQuery = "CREATE TABLE IF NOT EXISTS Productos (idProducto INTEGER PRIMARY KEY, Descripcion TEXT, Precio REAL)";
    using (SqliteCommand createTableCmd = new SqliteCommand(createTableQuery, connection))
    {
        createTableCmd.ExecuteNonQuery();
        Console.WriteLine("Tabla 'productos' creada o ya existe.");
    }
    
    // Insertar un Producto
    string insertQuery = "INSERT INTO Productos (Descripcion, Precio) VALUES ('Manzana', 0.50), ('Banana', 0.30)";
    using (SqliteCommand insertCmd = new SqliteCommand(insertQuery, connection))
    {
        insertCmd.ExecuteNonQuery();
        Console.WriteLine("Datos insertados en la tabla 'productos'.");
    }
    //iNSERTAR UN Presupuesto
    string insertQuery2 = "INSERT INTO Presupuestos (NombreDestinatario, FechaCreacion) VALUES ('Carlos Ruiz', '2024-10-25')";
    using (SqliteCommand insertCmd = new SqliteCommand(insertQuery2, connection))
    {
        insertCmd.ExecuteNonQuery();
        Console.WriteLine("Datos insertados en la tabla 'Presupuestos'.");
    }   
     //Insertar registros en PresupuestosDetalle
    string insertQuery3 = "INSERT INTO PresupuestosDetalle (idPresupuesto, idProducto, Cantidad) VALUES (1,3,2)";
    using (SqliteCommand insertCmd = new SqliteCommand(insertQuery3, connection))
    {
        insertCmd.ExecuteNonQuery();
        Console.WriteLine("Datos insertados en la tabla 'PresupuestosDetalle'.");
    }
    //Modificar Un producto
    string modificarProducto = "UODATE Productos SET Descripcion = 'Teclado Mecánico Logitech',Precio = 12000 WHERE idProducto = 3";
    using (SqliteCommand modif = new SqliteCommand(modificarProducto, connection))
    {
        modif.ExecuteNonQuery();
        Console.WriteLine("Modifico un producto");
    }
    //Modificar NombreDestinatario de Presupuesto
    string modificarPresupuesto = "UPDATE Presupuestos SET NombreDestinatario = 'Luis Fernández' WHERE idPresupuesto = 1";
    using (SqliteCommand modif = new SqliteCommand(modificarPresupuesto, connection))
    {
        modif.ExecuteNonQuery();
        Console.WriteLine("Se modifico el NombreDestinatario del Presupuesto con idPresupuesto=1");
    }
    //eliminar un registro de la tabla PresupuestosDetalle
    string eliminarDetalle = "DELETE FROM PresupuestosDetalle WHERE idPresupuesto = 1 AND idProducto = 2";
    using (SqliteCommand eliminarCmd = new SqliteCommand(eliminarDetalle, connection))
    {
        eliminarCmd.ExecuteNonQuery();
        Console.WriteLine("Registro eliminado correctamente de PresupuestoDetalle");
    }    // Leer datos
        string selectQuery = "SELECT * FROM Productos";
            using (SqliteCommand selectCmd = new SqliteCommand(selectQuery, connection))
            using (SqliteDataReader reader = selectCmd.ExecuteReader())
            {
                Console.WriteLine("Datos en la tabla 'productos':");
                while (reader.Read())
                {
                    Console.WriteLine($"ID: {reader["idProducto"]}, Descripcion: {reader["Descripcion"]}, Precio: {reader["Precio"]}");
                }
            }

            connection.Close();
}