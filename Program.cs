// Etapa 1: Bienvenida y datos del comercio
const string NombreComercio = "KIOSCO EL RECREO";

Console.WriteLine($"=== {NombreComercio} ===");
Console.Write("Nombre del cajero: ");
string nombreCajero = Console.ReadLine();
Console.WriteLine($"Bienvenida, {nombreCajero}. Caja abierta.\n");

// Variables para la venta (Etapa 2 y 3)
decimal totalGeneral = 0;
int cantidadProductos = 0;
int opcion;

// Etapa 3: Carga múltiple con menú usando do-while
do
{
    Console.WriteLine("\n¿Qué desea hacer?");
    Console.WriteLine("1 - Cargar un producto");
    Console.WriteLine("2 - Cerrar la venta");
    Console.Write("Elija una opción: ");

    // Validamos que la opción ingresada sea un número entero
    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        // Usamos switch para resolver la opción elegida
        switch (opcion)
        {
            case 1:
                // Etapa 2: Cargar un producto
                Console.Write("Ingrese el nombre del producto: ");
                string nombreProducto = Console.ReadLine();

                Console.Write("Ingrese el precio del producto: ");
                // Prestar atención: usamos decimal para el precio
                if (decimal.TryParse(Console.ReadLine(), out decimal precio))
                {
                    totalGeneral += precio;
                    cantidadProductos++;
                    Console.WriteLine($"-> Producto cargado: {nombreProducto} (${precio})");
                }
                else
                {
                    Console.WriteLine("❌ Precio inválido. Intente cargar el producto nuevamente.");
                }
                break;

            case 2:
                // Cierre de venta básico por ahora
                Console.WriteLine("\n--- CIERRE DE VENTA ---");
                Console.WriteLine($"Cantidad de productos: {cantidadProductos}");
                Console.WriteLine($"Total a pagar: ${totalGeneral}");
                break;

            default:
                Console.WriteLine("❌ Opción inválida. Ingrese 1 o 2.");
                break;
        }
    }
    else
    {
        Console.WriteLine("❌ Por favor, ingrese un número válido.");
        opcion = 0; // Forzamos a que repita el bucle si ingresó letras
    }

} while (opcion != 2);

Console.WriteLine("\nGracias por su compra.");
Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadLine();

