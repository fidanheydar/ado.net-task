
using System.Data.SqlClient;

string connection = "Server=FI;Database=Kfc;Trusted_Connection=True";
SqlConnection sqlConnection = new SqlConnection(connection);

bool IsRun = true;

Console.WriteLine("1-Create Product");
Console.WriteLine("2-ShowAll Products");
Console.WriteLine("3-GetProductById");
Console.WriteLine("4-Update Product");
Console.WriteLine("5-Create Category");
Console.WriteLine("6-ShowAll Categories");
Console.WriteLine("7-GetCategoryById");
Console.WriteLine("8-Update Category");
Console.WriteLine("9-Quit");
int.TryParse(Console.ReadLine(), out int request);
while (IsRun)
{
    switch (request) { 
        case 0:
            return;
        case 1:
            Console.Clear();
            CreateProduct();
            break;
            case 2:
            Console.Clear();
            ShowAllProudcts();
            break;
            case 3:
            Console.Clear();
            GetProductById();
                break;
            case 4:
            Console.Clear();
            UpdateProduct();
            break;
            case 5:
            Console.Clear();
            CreateCategory();
            break;
            case 6:
            Console.Clear();
            ShowAllCategories();
            break;
            case 7:
            Console.Clear();
            GetCategoryById();
            break;
            case 8:
            Console.Clear();
            UpdateCategory();
            break;
        case 9:
            Console.Clear();
            Console.WriteLine("Add valid option");
            break;

    }

    Console.WriteLine("1-Create Product");
    Console.WriteLine("2-ShowAll Products");
    Console.WriteLine("3-GetProductById");
    Console.WriteLine("4-Update Product");
    Console.WriteLine("5-Create Category");
    Console.WriteLine("6-ShowAll Categories");
    Console.WriteLine("7-GetCategoryById");
    Console.WriteLine("8-Update Category");
    Console.WriteLine("9-Quit");
    //int.TryParse(Console.ReadLine(), out int request);


}

void CreateProduct()
{
Console.WriteLine("Add Product Name");
string name = Console.ReadLine();
Console.WriteLine("Add Category Id:");
    int.TryParse(Console.ReadLine(), out int categoryId);
    SqlCommand cmd = new SqlCommand($"INSERT INTO Products VALUES('{name}','{categoryId}')",sqlConnection);
    sqlConnection.Open();
    sqlConnection.Open();
    cmd.ExecuteNonQuery();
    sqlConnection.Close();
}

void ShowAllProudcts()
{
    SqlCommand cmd = new SqlCommand($"SELECT * FROM Products", sqlConnection);
    sqlConnection.Open();
    var result = cmd.ExecuteReader();
    while (result.Read())
    {
        Console.WriteLine(result["Id"] + " " + result["Name"]);
    }
    sqlConnection.Close();
}

void GetProductById()
{
    Console.WriteLine("Add Product Id");
    int.TryParse(Console.ReadLine(), out int Id);

    SqlCommand cmd1 = new SqlCommand($"SELECT * FROM Products WHERE Id = {Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader = cmd1.ExecuteReader();
    bool status = false;
    while (reader.Read())
    {
        Console.WriteLine(reader["Id"] + " " + reader["Name"]);
        status = true;
        if (!status)
        {
            Console.WriteLine("Product is not found");
        }
        sqlConnection.Close();
    }
}


void UpdateProduct()
{
    Console.WriteLine("Add Product Id");
    int.TryParse(Console.ReadLine(), out int Id);
    SqlCommand cmd1 = new SqlCommand($"SELECT * FROM Products WHERE Id={Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader = cmd1.ExecuteReader();

    if (reader.Read())
    {
        sqlConnection.Close();
        sqlConnection.Open();
        Console.WriteLine("Update Product Name");
        SqlCommand cmd2 = new SqlCommand($"UPDATE Products SET Name = '{Console.ReadLine()}' WHERE Id = {Id};", sqlConnection);
        cmd2.ExecuteNonQuery();
    }
    else
    {
        Console.WriteLine("Product is not found");
    }
    sqlConnection.Close();
}

void CreateCategory()
{
    Console.WriteLine("Add Category Name");
    string name = Console.ReadLine();
    SqlCommand cmd = new SqlCommand($"INSERT INTO Categoryes VALUES('{name}')", sqlConnection);
    sqlConnection.Open();
    cmd.ExecuteNonQuery();
    sqlConnection.Close();
}
void ShowAllCategories()
{
    SqlCommand cmd = new SqlCommand("SELECT C.Id 'CategoryId', C.Name 'CategoryName',P.Name 'ProductName' FROM Categoryes as C LEFT JOIN Products as P ON C.Id=P.CategoryId", sqlConnection);
    sqlConnection.Open();
    var result = cmd.ExecuteReader();
    while (result.Read())
    {
        Console.WriteLine(result["CategoryId"] + " " + result["CategoryName"] + " " + result["ProductName"]);
    }
    sqlConnection.Close();
}



void GetCategoryById()
{
    Console.WriteLine("Add Category Id");
    int.TryParse(Console.ReadLine(), out int Id);

    SqlCommand cmd1 = new SqlCommand($"SELECT * FROM Categoryes WHERE  Id = {Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader = cmd1.ExecuteReader();
    bool status = false;
    while (reader.Read())
    {
        Console.WriteLine(reader["Id"] + " " + reader["Name"]);
        status = true;
    }
    if (!status)
    {
        Console.WriteLine("Category is not found");
    }
    sqlConnection.Close();
}
void UpdateCategory()
{
    Console.WriteLine("Add Category Id");
    int.TryParse(Console.ReadLine(), out int Id);
    SqlCommand cmd1 = new SqlCommand($"SELECT * FROM Categoryes WHERE  Id={Id}", sqlConnection);
    sqlConnection.Open();
    SqlDataReader reader = cmd1.ExecuteReader();
    if (reader.Read())
    {
        sqlConnection.Close();
        sqlConnection.Open();
        Console.WriteLine("Update Category Name");
        string name = Console.ReadLine();
        SqlCommand cmd2 = new SqlCommand($"UPDATE Categoryes SET Name = '{name}' WHERE Id = {Id};", sqlConnection);
        cmd2.ExecuteNonQuery();
    }
    else
    {
        Console.WriteLine("Category is not found");
    }
    sqlConnection.Close();
}