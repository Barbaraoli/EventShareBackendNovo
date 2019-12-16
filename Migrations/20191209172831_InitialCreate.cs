using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PROJETO.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "evento_categoria_tbl",
                columns: table => new
                {
                    categoria_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    categoria_nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evento_c__DB875A4FF7544FBE", x => x.categoria_id);
                });

            migrationBuilder.CreateTable(
                name: "evento_espaco_tbl",
                columns: table => new
                {
                    espaco_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    espaco_nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evento_e__01BC6094BBFE2231", x => x.espaco_id);
                });

            migrationBuilder.CreateTable(
                name: "evento_status_tbl",
                columns: table => new
                {
                    evento_status_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evento_status_nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evento_s__F2753B700300C754", x => x.evento_status_id);
                });

            migrationBuilder.CreateTable(
                name: "usuario_tipo_tbl",
                columns: table => new
                {
                    tipo_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tipo_nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuario___6EA5A01B2E59D269", x => x.tipo_id);
                });

            migrationBuilder.CreateTable(
                name: "usuario_tbl",
                columns: table => new
                {
                    usuario_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usuario_nome = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    usuario_email = table.Column<string>(unicode: false, maxLength: 100, nullable: false),
                    usuario_comunidade = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    usuario_senha = table.Column<string>(unicode: false, maxLength: 255, nullable: true),
                    usuario_tipo_id = table.Column<int>(nullable: true),
                    usuario_imagem = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__usuario___2ED7D2AFB0CD79B4", x => x.usuario_id);
                    table.ForeignKey(
                        name: "FK__usuario_t__usuar__3F466844",
                        column: x => x.usuario_tipo_id,
                        principalTable: "usuario_tipo_tbl",
                        principalColumn: "tipo_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "evento_tbl",
                columns: table => new
                {
                    evento_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    evento_nome = table.Column<string>(unicode: false, maxLength: 100, nullable: true),
                    evento_data = table.Column<DateTime>(type: "date", nullable: true),
                    evento_horario_comeco = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    evento_horario_fim = table.Column<string>(unicode: false, maxLength: 50, nullable: true),
                    evento_descricao = table.Column<string>(type: "text", nullable: true),
                    evento_categoria_id = table.Column<int>(nullable: true),
                    evento_espaco_id = table.Column<int>(nullable: false),
                    evento_status_id = table.Column<int>(nullable: true),
                    criador_usuario_id = table.Column<int>(nullable: true),
                    responsavel_usuario_id = table.Column<int>(nullable: true),
                    evento_imagem = table.Column<string>(maxLength: 250, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__evento_t__1850C3AD331734B5", x => x.evento_id);
                    table.ForeignKey(
                        name: "FK__evento_tb__criad__44FF419A",
                        column: x => x.criador_usuario_id,
                        principalTable: "usuario_tbl",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__evento_tb__event__4222D4EF",
                        column: x => x.evento_categoria_id,
                        principalTable: "evento_categoria_tbl",
                        principalColumn: "categoria_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__evento_tb__event__4316F928",
                        column: x => x.evento_espaco_id,
                        principalTable: "evento_espaco_tbl",
                        principalColumn: "espaco_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK__evento_tb__event__440B1D61",
                        column: x => x.evento_status_id,
                        principalTable: "evento_status_tbl",
                        principalColumn: "evento_status_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK__evento_tb__respo__45F365D3",
                        column: x => x.responsavel_usuario_id,
                        principalTable: "usuario_tbl",
                        principalColumn: "usuario_id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_evento_tbl_criador_usuario_id",
                table: "evento_tbl",
                column: "criador_usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_evento_tbl_evento_categoria_id",
                table: "evento_tbl",
                column: "evento_categoria_id");

            migrationBuilder.CreateIndex(
                name: "IX_evento_tbl_evento_espaco_id",
                table: "evento_tbl",
                column: "evento_espaco_id");

            migrationBuilder.CreateIndex(
                name: "IX_evento_tbl_evento_status_id",
                table: "evento_tbl",
                column: "evento_status_id");

            migrationBuilder.CreateIndex(
                name: "IX_evento_tbl_responsavel_usuario_id",
                table: "evento_tbl",
                column: "responsavel_usuario_id");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_tbl_usuario_tipo_id",
                table: "usuario_tbl",
                column: "usuario_tipo_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "evento_tbl");

            migrationBuilder.DropTable(
                name: "usuario_tbl");

            migrationBuilder.DropTable(
                name: "evento_categoria_tbl");

            migrationBuilder.DropTable(
                name: "evento_espaco_tbl");

            migrationBuilder.DropTable(
                name: "evento_status_tbl");

            migrationBuilder.DropTable(
                name: "usuario_tipo_tbl");
        }
    }
}
