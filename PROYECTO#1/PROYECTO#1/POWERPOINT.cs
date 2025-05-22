using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Presentation;
using A = DocumentFormat.OpenXml.Drawing;

namespace PROYECTO_1
{
    internal class POWERPOINT
    {
        private Shape CreateTextShape(uint id, string name, string text, long x, long y, long cx, long cy)
        {
            return new Shape(
                new NonVisualShapeProperties(
                    new NonVisualDrawingProperties() { Id = id, Name = name },
                    new NonVisualShapeDrawingProperties(new A.ShapeLocks() { NoGrouping = true }),
                    new ApplicationNonVisualDrawingProperties()
                ),
                new ShapeProperties(
                    new A.Transform2D(
                        new A.Offset() { X = x, Y = y },
                        new A.Extents() { Cx = cx, Cy = cy }
                    )
                ),
                new TextBody(
                    new A.BodyProperties(),
                    new A.ListStyle(),
                    new A.Paragraph(
                        new A.Run(new A.Text(text))
                    )
                )
            );
        }
        public void documentoPowerPoint(string ruta, string titulo, string cuerpo)
        {
            if (string.IsNullOrWhiteSpace(ruta))
            {
                MessageBox.Show("La ruta está vacía o es nula.");
                return;
            }

            if (!Directory.Exists(ruta))
            {
                Directory.CreateDirectory(ruta);
            }

            string nombreArchivo = Path.Combine(ruta, $"documento_{DateTime.Now:yyyyMMdd_HHmmss}.pptx");


            using (PresentationDocument presentationDoc = PresentationDocument.Create(nombreArchivo, PresentationDocumentType.Presentation))
            {
                PresentationPart presentationPart = presentationDoc.AddPresentationPart();
                presentationPart.Presentation = new Presentation();

                SlideMasterPart slideMasterPart = presentationPart.AddNewPart<SlideMasterPart>();
                slideMasterPart.SlideMaster = new SlideMaster(new CommonSlideData(new ShapeTree()));

                SlideLayoutPart slideLayoutPart = slideMasterPart.AddNewPart<SlideLayoutPart>();
                slideLayoutPart.SlideLayout = new SlideLayout(new CommonSlideData(new ShapeTree()));

                slideMasterPart.SlideMaster.AppendChild(new SlideLayoutIdList(
                    new SlideLayoutId() { Id = 1U, RelationshipId = slideMasterPart.GetIdOfPart(slideLayoutPart) }));

                presentationPart.Presentation.AppendChild(new SlideMasterIdList(
                    new SlideMasterId() { Id = 1U, RelationshipId = presentationPart.GetIdOfPart(slideMasterPart) }));

                SlidePart slidePart = presentationPart.AddNewPart<SlidePart>();
                slidePart.Slide = new Slide(new CommonSlideData(new ShapeTree()));
                slidePart.AddPart(slideLayoutPart);

                SlideIdList slideIdList = new SlideIdList();
                uint slideId = 256U;
                SlideId slideIdElement = new SlideId() { Id = slideId, RelationshipId = presentationPart.GetIdOfPart(slidePart) };
                slideIdList.Append(slideIdElement);
                presentationPart.Presentation.AppendChild(slideIdList);

                var shapeTree = slidePart.Slide.CommonSlideData.ShapeTree;

                shapeTree.AppendChild(new NonVisualGroupShapeProperties(
                    new NonVisualDrawingProperties() { Id = 1U, Name = "" },
                    new NonVisualGroupShapeDrawingProperties(),
                    new ApplicationNonVisualDrawingProperties()));
                shapeTree.AppendChild(new GroupShapeProperties());

                
                shapeTree.Append(CreateTextShape(2U, "Título", titulo, 1000000L, 1000000L, 8000000L, 1000000L));

                
                shapeTree.Append(CreateTextShape(3U, "Cuerpo", cuerpo, 1000000L, 2200000L, 8000000L, 4000000L));

                presentationPart.Presentation.Save();
            }
        }
        
    }
}

