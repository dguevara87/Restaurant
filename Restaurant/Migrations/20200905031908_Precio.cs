using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Restaurant.Migrations
{
    public partial class Precio : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CentrosElaboracion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CentrosElaboracion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionClientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    PrecioPorciento = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionClientes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionIngrediente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionIngrediente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ClasificacionProducto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClasificacionProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Empleado",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido1 = table.Column<string>(nullable: true),
                    Apellido2 = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empleado", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoMesa",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoMesa", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoOrden",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoOrden", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoOrdenProducto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoOrdenProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoProducto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoProducto", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PreciosAreas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    Precio = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreciosAreas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ubicacion",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ubicacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UnidadesMedidas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UnidadesMedidas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Identificacion = table.Column<string>(nullable: true),
                    Codigo = table.Column<string>(nullable: true),
                    Nombre = table.Column<string>(nullable: true),
                    Apellido1 = table.Column<string>(nullable: true),
                    Apellido2 = table.Column<string>(nullable: true),
                    Visitas = table.Column<int>(nullable: false),
                    ClasificacionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clientes_ClasificacionClientes_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "ClasificacionClientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Productos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    Descripcion = table.Column<string>(nullable: true),
                    Precio = table.Column<decimal>(nullable: false),
                    EstadoId = table.Column<Guid>(nullable: true),
                    ClasificacionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Productos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Productos_ClasificacionProducto_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "ClasificacionProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Productos_EstadoProducto_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    UbicacionId = table.Column<Guid>(nullable: true),
                    PrecioAreaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Area_PreciosAreas_PrecioAreaId",
                        column: x => x.PrecioAreaId,
                        principalTable: "PreciosAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Area_Ubicacion_UbicacionId",
                        column: x => x.UbicacionId,
                        principalTable: "Ubicacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Ingrediente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(maxLength: 30, nullable: false),
                    Descripcion = table.Column<string>(maxLength: 100, nullable: false),
                    Existencia = table.Column<decimal>(nullable: false),
                    UnidadMedidaId = table.Column<Guid>(nullable: true),
                    ClasificacionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingrediente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Ingrediente_ClasificacionIngrediente_ClasificacionId",
                        column: x => x.ClasificacionId,
                        principalTable: "ClasificacionIngrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Ingrediente_UnidadesMedidas_UnidadMedidaId",
                        column: x => x.UnidadMedidaId,
                        principalTable: "UnidadesMedidas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Reservas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Fecha = table.Column<DateTime>(nullable: false),
                    NumPersonas = table.Column<int>(nullable: false),
                    Reserva = table.Column<string>(nullable: true),
                    EmpleadoId = table.Column<Guid>(nullable: true),
                    ClienteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reservas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Reservas_Clientes_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Clientes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Reservas_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AreaCentroElab",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    AreaId = table.Column<Guid>(nullable: false),
                    CentroElaboracionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaCentroElab", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreaCentroElab_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AreaCentroElab_CentrosElaboracion_CentroElaboracionId",
                        column: x => x.CentroElaboracionId,
                        principalTable: "CentrosElaboracion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nombre = table.Column<string>(nullable: true),
                    AreaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Menus_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "IngredienteProducto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ProductoId = table.Column<Guid>(nullable: false),
                    IngredienteId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IngredienteProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_IngredienteProducto_Ingrediente_IngredienteId",
                        column: x => x.IngredienteId,
                        principalTable: "Ingrediente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IngredienteProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mesas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Capacidad = table.Column<int>(nullable: false),
                    EstadoId = table.Column<Guid>(nullable: false),
                    ReservaId = table.Column<Guid>(nullable: true),
                    AreaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mesas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Mesas_Area_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Area",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Mesas_EstadoMesa_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoMesa",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mesas_Reservas_ReservaId",
                        column: x => x.ReservaId,
                        principalTable: "Reservas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProductoMenu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProductoId = table.Column<Guid>(nullable: true),
                    MenuId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductoMenu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductoMenu_Menus_MenuId",
                        column: x => x.MenuId,
                        principalTable: "Menus",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProductoMenu_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Orden",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Numero = table.Column<int>(nullable: false),
                    Descuento = table.Column<int>(nullable: false),
                    Importe = table.Column<decimal>(nullable: false),
                    Creada = table.Column<DateTime>(nullable: false),
                    Servida = table.Column<DateTime>(nullable: true),
                    Cobrada = table.Column<DateTime>(nullable: true),
                    EstadoId = table.Column<Guid>(nullable: false),
                    EsmpleadoId = table.Column<Guid>(nullable: false),
                    MesaId = table.Column<Guid>(nullable: true),
                    EmpleadoId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orden", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orden_Empleado_EmpleadoId",
                        column: x => x.EmpleadoId,
                        principalTable: "Empleado",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Orden_EstadoOrden_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoOrden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orden_Mesas_MesaId",
                        column: x => x.MesaId,
                        principalTable: "Mesas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrdenProducto",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Cantidad = table.Column<int>(nullable: false),
                    ProductoId = table.Column<Guid>(nullable: false),
                    OrdenId = table.Column<Guid>(nullable: false),
                    EstadoId = table.Column<Guid>(nullable: false),
                    CentroElaboracionId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrdenProducto", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrdenProducto_CentrosElaboracion_CentroElaboracionId",
                        column: x => x.CentroElaboracionId,
                        principalTable: "CentrosElaboracion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OrdenProducto_EstadoOrdenProducto_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoOrdenProducto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenProducto_Orden_OrdenId",
                        column: x => x.OrdenId,
                        principalTable: "Orden",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_OrdenProducto_Productos_ProductoId",
                        column: x => x.ProductoId,
                        principalTable: "Productos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Area_PrecioAreaId",
                table: "Area",
                column: "PrecioAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Area_UbicacionId",
                table: "Area",
                column: "UbicacionId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaCentroElab_AreaId",
                table: "AreaCentroElab",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_AreaCentroElab_CentroElaboracionId",
                table: "AreaCentroElab",
                column: "CentroElaboracionId");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_ClasificacionId",
                table: "Clientes",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_ClasificacionId",
                table: "Ingrediente",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Ingrediente_UnidadMedidaId",
                table: "Ingrediente",
                column: "UnidadMedidaId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteProducto_IngredienteId",
                table: "IngredienteProducto",
                column: "IngredienteId");

            migrationBuilder.CreateIndex(
                name: "IX_IngredienteProducto_ProductoId",
                table: "IngredienteProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Menus_AreaId",
                table: "Menus",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_AreaId",
                table: "Mesas",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_EstadoId",
                table: "Mesas",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Mesas_ReservaId",
                table: "Mesas",
                column: "ReservaId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_EmpleadoId",
                table: "Orden",
                column: "EmpleadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_EstadoId",
                table: "Orden",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Orden_MesaId",
                table: "Orden",
                column: "MesaId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenProducto_CentroElaboracionId",
                table: "OrdenProducto",
                column: "CentroElaboracionId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenProducto_EstadoId",
                table: "OrdenProducto",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenProducto_OrdenId",
                table: "OrdenProducto",
                column: "OrdenId");

            migrationBuilder.CreateIndex(
                name: "IX_OrdenProducto_ProductoId",
                table: "OrdenProducto",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMenu_MenuId",
                table: "ProductoMenu",
                column: "MenuId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductoMenu_ProductoId",
                table: "ProductoMenu",
                column: "ProductoId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_ClasificacionId",
                table: "Productos",
                column: "ClasificacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Productos_EstadoId",
                table: "Productos",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_ClienteId",
                table: "Reservas",
                column: "ClienteId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservas_EmpleadoId",
                table: "Reservas",
                column: "EmpleadoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaCentroElab");

            migrationBuilder.DropTable(
                name: "IngredienteProducto");

            migrationBuilder.DropTable(
                name: "OrdenProducto");

            migrationBuilder.DropTable(
                name: "ProductoMenu");

            migrationBuilder.DropTable(
                name: "Ingrediente");

            migrationBuilder.DropTable(
                name: "CentrosElaboracion");

            migrationBuilder.DropTable(
                name: "EstadoOrdenProducto");

            migrationBuilder.DropTable(
                name: "Orden");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Productos");

            migrationBuilder.DropTable(
                name: "ClasificacionIngrediente");

            migrationBuilder.DropTable(
                name: "UnidadesMedidas");

            migrationBuilder.DropTable(
                name: "EstadoOrden");

            migrationBuilder.DropTable(
                name: "Mesas");

            migrationBuilder.DropTable(
                name: "ClasificacionProducto");

            migrationBuilder.DropTable(
                name: "EstadoProducto");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "EstadoMesa");

            migrationBuilder.DropTable(
                name: "Reservas");

            migrationBuilder.DropTable(
                name: "PreciosAreas");

            migrationBuilder.DropTable(
                name: "Ubicacion");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Empleado");

            migrationBuilder.DropTable(
                name: "ClasificacionClientes");
        }
    }
}
