// Constantes del comercio y de las etapas 4 y 5
const string NombreComercio = "KIOSCO EL RECREO";

const decimal PorcentajeDescuentoAlto = 0.10m; // 10%
const decimal PorcentajeDescuentoMedio = 0.05m; // 5%
const decimal MontoMinimoAlto = 50000m;
const decimal MontoMinimoMedio = 20000m;

const decimal DescuentoEfectivo = 0.10m; // 10% adicional
const decimal RecargoCredito = 0.15m;   // 15% de recargo

// Etapa 1: Bienvenida y datos del comercio
Console.WriteLine($"=== {NombreComercio} ===");
Console.Write("Nombre del cajero: ");
string nombreCajero = Console.ReadLine();
Console.WriteLine($"Bienvenida, {nombreCajero}. Caja abierta.\n");

decimal totalGeneral = 0;
int cantidadProductos = 0;
int opcion;

// Etapa 3: Carga múltiple con menú
do
{
    Console.WriteLine("\n¿Qué desea hacer?");
    Console.WriteLine("1 - Cargar un producto");
    Console.WriteLine("2 - Cerrar la venta");
    Console.Write("Elija una opción: ");

    if (int.TryParse(Console.ReadLine(), out opcion))
    {
        switch (opcion)
        {
            case 1:
                Console.Write("Ingrese el nombre del producto: ");
                string nombreProducto = Console.ReadLine();

                Console.Write("Ingrese el precio del producto: ");
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
                if (cantidadProductos == 0)
                {
                    Console.WriteLine("❌ No se puede cerrar la venta sin productos cargados.");
                    opcion = 0;
                    break;
                }

                // Etapa 4: Cálculo de descuentos por monto
                decimal descuentoMonto = 0;

                if (totalGeneral > MontoMinimoAlto)
                {
                    descuentoMonto = totalGeneral * PorcentajeDescuentoAlto;
                }
                else if (totalGeneral > MontoMinimoMedio)
                {
                    descuentoMonto = totalGeneral * PorcentajeDescuentoMedio;
                }
                else
                {
                    descuentoMonto = 0;
                }

                decimal subtotalConDescuento = totalGeneral - descuentoMonto;

                // Etapa 5: Elección del medio de pago
                int medioPago = 0;
                decimal descuentoMedioPago = 0;
                decimal recargoMedioPago = 0;
                bool medioPagoValido = false;

                while (!medioPagoValido)
                {
                    Console.WriteLine("\nMedio de pago:");
                    Console.WriteLine("1 - Efectivo (10% adicional de descuento)");
                    Console.WriteLine("2 - Débito (Sin cambios)");
                    Console.WriteLine("3 - Crédito (15% de recargo)");
                    Console.Write("Elija una opción de pago: ");

                    if (int.TryParse(Console.ReadLine(), out medioPago))
                    {
                        switch (medioPago)
                        {
                            case 1:
                                descuentoMedioPago = subtotalConDescuento * DescuentoEfectivo;
                                medioPagoValido = true;
                                break;
                            case 2:
                                medioPagoValido = true;
                                break;
                            case 3:
                                recargoMedioPago = subtotalConDescuento * RecargoCredito;
                                medioPagoValido = true;
                                break;
                            default:
                                Console.WriteLine("❌ Opción de pago inválida. Intente nuevamente.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("❌ Por favor, ingrese un número válido.");
                    }
                }

                decimal totalFinal = subtotalConDescuento - descuentoMedioPago + recargoMedioPago;

                // Etapa 6: Generar línea de guiones con bucle for
                string lineaGuiones = "";
                for (int i = 0; i < 30; i++)
                {
                    lineaGuiones += "-";
                }

                // Mostrar el Ticket Final
                Console.WriteLine($"\n{lineaGuiones}");
                Console.WriteLine($"       {NombreComercio}");
                Console.WriteLine($"{lineaGuiones}");
                Console.WriteLine($"Cajero: {nombreCajero}");
                Console.WriteLine($"Productos: {cantidadProductos}");
                Console.WriteLine($"Subtotal: ${totalGeneral}");
                Console.WriteLine($"Descuento: ${descuentoMonto + descuentoMedioPago}");
                Console.WriteLine($"Recargo: ${recargoMedioPago}");
                Console.WriteLine($"{lineaGuiones}");
                Console.WriteLine($"TOTAL: ${totalFinal}");
                Console.WriteLine($"{lineaGuiones}");
                break;

            default:
                Console.WriteLine("❌ Opción inválida. Ingrese 1 o 2.");
                break;
        }
    }
    else
    {
        Console.WriteLine("❌ Por favor, ingrese un número válido.");
        opcion = 0;
    }

} while (opcion != 2);

Console.WriteLine("\nGracias por su compra.");
Console.WriteLine("\nPresione cualquier tecla para salir...");
Console.ReadLine();