using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Windows.Forms;
using PROYECTO_1.LOGICA___;
using Newtonsoft.Json;
using Microsoft.Identity.Client;
using System.Text.Json;

namespace PROYECTO_1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private async void btnBuscar_Click_Click(object sender, EventArgs e)
        {
            string prompt = textBuscar_Click.Text;

            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("Authorization", "Bearer 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");

                var body = new
                {
                    model = "mistralai/mistral-7b-instruct:free",
                    messages = new[]
                    {
             new { role = "user", content = prompt}
         }
                };

                string json = JsonConvert.SerializeObject(body);
                var content = new StringContent(json, Encoding.UTF8, "application/json");

                var response = await client.PostAsync("https://openrouter.ai/api/v1/chat/completions", content);
                string result = await response.Content.ReadAsStringAsync();

                dynamic respuesta = JsonConvert.DeserializeObject(result);
                txtRespuesta.Text = respuesta.choices[0].message.content;
                Proyecto_1.GuardarEnBD(prompt, txtRespuesta.Text);
                Proyecto_1.CrearCarpeta();
                Proyecto_1.CrearWord(prompt, txtRespuesta.Text);
                // Crear archivo PowerPoint automáticamente
                string ruta = @"C:\Users\cccas\Desktop\archivosInvestigacion";
                string titulo = "Resultado de Investigación";
                string cuerpo = $"Pregunta: {prompt}\n\nRespuesta: {txtRespuesta.Text}";

                POWERPOINT ppt = new POWERPOINT();
                ppt.documentoPowerPoint(ruta, titulo, cuerpo);
            }
        }

        private void btnLimpiar_Click_Click(object sender, EventArgs e)
        {
            // Limpia el campo de búsqueda y el resultado
            textBuscar_Click.Text = string.Empty;
            txtRespuesta.Text = string.Empty;


            textBuscar_Click.Focus();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
} 






