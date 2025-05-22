using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient; 
using System.Data;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.IO;
using DocumentFormat.OpenXml;
namespace PROYECTO_1.LOGICA___

    
{
    public static class Proyecto_1
    {
        /// Funcion para guardar el resultado en la base de datos
        public static void GuardarEnBD(string prompt, string respuesta)
        {
            string connectionString = "Data Source=CRISTIAN\\SQLEXPRESS01;Initial Catalog=Proyecto_1;Integrated Security=True;TrustServerCertificate=True;";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "INSERT INTO ResearchResults (Prompt, Result) VALUES (@Prompt, @Result)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.Add("@Prompt", SqlDbType.NVarChar).Value = prompt;
                        command.Parameters.Add("@Result", SqlDbType.NVarChar).Value = respuesta;
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                // Aquí se puede loggear un error o lanzar una excepción
                Console.WriteLine("Error al guardar en BD: " + ex.Message);
                throw;
            }
        }

        /// funcion para crear la carpeta "archivosInvestigacion" en el escritorio
        public static void CrearCarpeta()
        {
            string archivosInvestigacion = @"C:\Users\Cccas\Desktop\archivosInvestigacion";

            if (!Directory.Exists(archivosInvestigacion))
            {
                Directory.CreateDirectory(archivosInvestigacion);
                Console.WriteLine("Carpeta 'archivosInvestigacion' creada correctamente!");
            }
            else
            {
                Console.WriteLine("La carpeta 'archivosInvestigacion' ya existe!");
            }
        }
        //CREAR WORD Y GUARDAR EN CARPETA
        public static void CrearWord(string prompt, string respuesta)
        {
            string folderPath = @"C:\Users\Cccas\Desktop\archivosInvestigacion";
            string fileName = $"{DateTime.Now:yyyyMMdd_HHmmss}_ResearchResult.docx";
            string filePath = Path.Combine(folderPath, fileName);
            using (WordprocessingDocument wordDocument = WordprocessingDocument.Create(filePath, DocumentFormat.OpenXml.WordprocessingDocumentType.Document))
            {
                MainDocumentPart mainPart = wordDocument.AddMainDocumentPart();
                mainPart.Document = new Document();
                Body body = new Body();
                Paragraph para1 = new Paragraph(new Run(new Text("Prompt: " + prompt)));
                Paragraph para2 = new Paragraph(new Run(new Text("Respuesta: " + respuesta)));
                body.Append(para1);
                body.Append(para2);
                mainPart.Document.Append(body);
                mainPart.Document.Save();
            }
        }


      


    }
}







