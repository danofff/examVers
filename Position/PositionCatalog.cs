using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;

namespace Position
{
    public class PositionCatalog
    {
        public string pathToPositionCatalog { get; set; } = "positionCatalog.xml";

        public List<Position> PositionsList { get; set; }
        public bool CreatePosition(Position position)
        {
            List<Position> positionsList = GetPositions();
            positionsList.Add(position);

            XmlSerializer formatter = new XmlSerializer(typeof(List<Position>));
            try
            {
                using (FileStream fs = new FileStream(pathToPositionCatalog, FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, positionsList);
                }
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }
        public List<Position> GetPositions()
        {
            List<Position> positions = new List<Position>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Position>));
            FileInfo fi = new FileInfo(pathToPositionCatalog);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToPositionCatalog, FileMode.OpenOrCreate))
                {
                    positions = (List<Position>)formatter.Deserialize(fs);
                }
            }
            return positions == null ? new List<Position>() : positions;
        }

        public void DeletePosition(position pos)
        {
            List<Position> positions = new List<Position>();
            XmlSerializer formatter = new XmlSerializer(typeof(List<Position>));
            FileInfo fi = new FileInfo(pathToPositionCatalog);
            if (fi.Exists)
            {
                using (FileStream fs = new FileStream(pathToPositionCatalog, FileMode.OpenOrCreate))
                {
                    positions = (List<Position>)formatter.Deserialize(fs);
                }

                for (int i = 0; i < positions.Count; i++)
                {
                    if (positions[i].PositionName == pos)
                    {
                        positions.Remove(positions[i]);
                        break;
                    }
                }

               try
                {
                    using (FileStream fs = new FileStream(pathToPositionCatalog, FileMode.OpenOrCreate))
                    {
                        formatter.Serialize(fs, positions);
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }   
        }
    }
}
