using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ds;
using DalApi;
using DO;


namespace DalObject
{
    public partial class DOImp:IDal
    {
        public void CreateLine(Line line)
        {
            DataSource.LineList.Add(line);
        }

        public Line RequestLine(long id)
        {
            return DataSource.LineList.Find(l=>l.Id == id);
        }

        public void UpdateLine(Line line)
        {
            int indLine;
            if (line.Id != null)
            {
                indLine = DataSource.LineList.FindIndex(l => l.Id == line.Id);
                DataSource.LineList[indLine] = line;
            }
            else
                throw new Exception("line doesn't exist!!");
        }

        public void DeleteLine(Line line)
        {
            if (line.Id != null)
                DataSource.LineList.Remove(line);
            else
                throw new Exception("line doesn't exist!!");
        }

        public IEnumerable<Line> GetAllLines(Func<Line, bool> predicate = null)
        {
            return from b in DataSource.LineList
                   where (predicate(b))
                   select b;
        }
    }
}
