using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LabSchoolApi.Migrations
{
    /// <inheritdoc />
    public partial class LabSchool : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SituacaoMatricula = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NotaProcessoSeletivo = table.Column<float>(type: "real", nullable: false),
                    TotalDeAtendimentoPedagogicos = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Pedagogos",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TotalAtendimentosPedagogicos = table.Column<int>(type: "int", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pedagogos", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Professor",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FormacaoAcademica = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExperienciaEmDesenvolvimento = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataNascimento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cpf = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Professor", x => x.Codigo);
                });
            migrationBuilder.Sql("INSERT INTO Aluno(Nome,Telefone,DataNascimento,Cpf,SituacaoMatricula,NotaProcessoSeletivo,TotalDeAtendimentoPedagogicos) VALUES('Bart Simpson','11-11111-1212','20141029',11839750073,'IRREGULAR', 3.5,0)");
            migrationBuilder.Sql("INSERT INTO Aluno(Nome,Telefone,DataNascimento,Cpf,SituacaoMatricula,NotaProcessoSeletivo,TotalDeAtendimentoPedagogicos) VALUES('Lisa Simpson','11-22222-2222','20121029',17158947076,'ATIVO',10,0)");
            migrationBuilder.Sql("INSERT INTO Aluno(Nome,Telefone,DataNascimento,Cpf,SituacaoMatricula,NotaProcessoSeletivo,TotalDeAtendimentoPedagogicos) VALUES('Meggie Simpson','12-20002-2200','20191029',63701210020,'ATIVO',9,0)");
            migrationBuilder.Sql("INSERT INTO Aluno(Nome,Telefone,DataNascimento,Cpf,SituacaoMatricula,NotaProcessoSeletivo,TotalDeAtendimentoPedagogicos) VALUES('Milhouse Van Houten','11-33333-2222','20141029',30119137062,'ATIVO',8,0)");
            migrationBuilder.Sql("INSERT INTO Aluno(Nome,Telefone,DataNascimento,Cpf,SituacaoMatricula,NotaProcessoSeletivo,TotalDeAtendimentoPedagogicos) VALUES('Nelson Muntz','11-44333-4444','20071029',95704094015,'IRREGULAR',2,0)");

            migrationBuilder.Sql("INSERT INTO Professor(Nome,Telefone,DataNascimento,Cpf,FormacaoAcademica,ExperienciaEmDesenvolvimento,Estado) VALUES('Walter White','14-22998-1882','19821030',40539019011,'ATIVO','FULL_STACK','MESTRADO')");
            migrationBuilder.Sql("INSERT INTO Professor(Nome,Telefone,DataNascimento,Cpf,FormacaoAcademica,ExperienciaEmDesenvolvimento,Estado) VALUES('Jesse Pinkman','44-11111-1992','19971030',96107295097,'ATIVO','BACK_END','GRADUACAO_INCOMPLETA')");
            migrationBuilder.Sql("INSERT INTO Professor(Nome,Telefone,DataNascimento,Cpf,FormacaoAcademica,ExperienciaEmDesenvolvimento,Estado) VALUES('Hank Schrader','44-11111-1002','19841030',70685977005,'ATIVO','FULL_STACK','MESTRADO')");
            migrationBuilder.Sql("INSERT INTO Professor(Nome,Telefone,DataNascimento,Cpf,FormacaoAcademica,ExperienciaEmDesenvolvimento,Estado) VALUES('Gustavo Fring','44-11001-1002','19771030',57408927085,'INATIVO','FRONT_END','GRADUACAO_COMPLETA')");
            migrationBuilder.Sql("INSERT INTO Professor(Nome,Telefone,DataNascimento,Cpf,FormacaoAcademica,ExperienciaEmDesenvolvimento,Estado) VALUES('Saul Goodman','44-11998-1882','19801030',86940162062,'ATIVO','FULL_STACK','MESTRADO')");

            migrationBuilder.Sql("INSERT INTO Pedagogos(Nome,Telefone,DataNascimento,Cpf,TotalAtendimentosPedagogicos) VALUES('John Snow','11-67333-4454','20001030',62316840086,0)");
            migrationBuilder.Sql("INSERT INTO Pedagogos(Nome,Telefone,DataNascimento,Cpf,TotalAtendimentosPedagogicos) VALUES('Sansa Stark','22-22333-4454','20041030',49850253053,0)");
            migrationBuilder.Sql("INSERT INTO Pedagogos(Nome,Telefone,DataNascimento,Cpf,TotalAtendimentosPedagogicos) VALUES('Tyrion Lannister','33-77333-4454','19901030',39125106015,0)");
            migrationBuilder.Sql("INSERT INTO Pedagogos(Nome,Telefone,DataNascimento,Cpf,TotalAtendimentosPedagogicos) VALUES('Sandor Clegane','11-33333-2222','19951030',89089606009,0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropTable(
                name: "Pedagogos");

            migrationBuilder.DropTable(
                name: "Professor");
        }
    }
}
