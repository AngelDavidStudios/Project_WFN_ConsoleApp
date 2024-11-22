using WFN.ConsoleSystem.Services;
using WFN.Models.Models;

class Program
{
    private static readonly BancoService _bancoService = new BancoService();

    static async Task Main(string[] args)
    {
        while (true)
        {
            string titulo = "--- Menú de Bancos ---";
            string separador = new string('=', 30);
            int anchoConsola = Console.WindowWidth;
            
            Console.WriteLine(separador.PadLeft((anchoConsola + separador.Length) / 2));
            Console.WriteLine(titulo.PadLeft((anchoConsola + titulo.Length) / 2));
            Console.WriteLine(separador.PadLeft((anchoConsola + separador.Length) / 2));
            Console.WriteLine();
            
            string[] opciones =
            {
                "1. Listar Bancos disponibles",
                "2. Agregar Banco",
                "3. Actualizar Banco",
                "4. Eliminar Banco",
                "5. Salir"
            };

            foreach (string opcion in opciones)
            {
                Console.WriteLine(opcion.PadLeft((anchoConsola + opcion.Length) / 2));
            }

            Console.WriteLine();
            string prompt = "Selecciona una opción: ";
            Console.Write(prompt.PadLeft((anchoConsola + prompt.Length) / 2));
            
            var option = Console.ReadLine();

            switch (option)
            {
                case "1":
                    await ListBancoAsync();
                    break;
                case "2":
                    await AddBancoAsync();
                    break;
                case "3":
                    await UpdateBancoAsync();
                    break;
                case "4":
                    await DeleteBancoAsync();
                    break;
                case "5":
                    return;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
    
    private static async Task ListBancoAsync()
    {
        try
        {
            var bancos = await _bancoService.GetBancos();
            if (bancos.Count == 0)
            {
                Console.WriteLine("No hay bancos registrados.");
                return;
            }
            
            Console.WriteLine("\n--- Lista de Bancos ---");
            Console.WriteLine($"{"ID Banco",-5} {"Nombre",-20} {"SWIFT",-30} {"Pais",-15} {"Sucursal",-30} {"Teléfono",-15}");
            Console.WriteLine(new string('-', 120));
            
            foreach (var banco in bancos)
            {
                Console.WriteLine($"{banco.IDBanco,-5} {banco.Nombre,-20} {banco.SWIFT,-30} {banco.Pais,-15} {banco.Sucursal,-30} {banco.Telefono,-15}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    private static async Task AddBancoAsync()
    {
        try
        {
            Console.Write("Nombre del Banco: ");
            string nombre = Console.ReadLine();
            Console.Write("SWIFT: ");
            string swift = Console.ReadLine();
            Console.Write("País: ");
            string pais = Console.ReadLine();
            Console.Write("Sucursal: ");
            string sucursal = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            var banco = new Entity_Banco()
            {
                Nombre = nombre,
                SWIFT = swift,
                Pais = pais,
                Sucursal = sucursal,
                Telefono = telefono
            };

            await _bancoService.AddBanco(banco);
            Console.WriteLine("Banco agregado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    private static async Task UpdateBancoAsync()
    {
        try
        {
            Console.Write("ID del Banco: ");
            int id = int.Parse(Console.ReadLine());
            Console.Write("Nombre del Banco: ");
            string nombre = Console.ReadLine();
            Console.Write("SWIFT: ");
            string swift = Console.ReadLine();
            Console.Write("País: ");
            string pais = Console.ReadLine();
            Console.Write("Sucursal: ");
            string sucursal = Console.ReadLine();
            Console.Write("Teléfono: ");
            string telefono = Console.ReadLine();

            var banco = new Entity_Banco()
            {
                IDBanco = id,
                Nombre = nombre,
                SWIFT = swift,
                Pais = pais,
                Sucursal = sucursal,
                Telefono = telefono
            };

            await _bancoService.UpdateBanco(banco);
            Console.WriteLine("Banco actualizado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
    
    private static async Task DeleteBancoAsync()
    {
        try
        {
            Console.Write("ID del Banco: ");
            int id = int.Parse(Console.ReadLine());
            await _bancoService.DeleteBanco(id);
            Console.WriteLine("Banco eliminado correctamente.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
    }
}