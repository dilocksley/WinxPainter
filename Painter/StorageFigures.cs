using Painter.Figures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Painter
{
    public abstract class StorageFigures
    {

       protected List<AFigure> aFigures = new List<AFigure>();

        public abstract void AddFigure(AFigure aFigure);
    }
}
