using System;
using System.Collections.Generic;
using System.Xml;
using BikeProductionPlanner.Logic.Database;

namespace BikeProductionPlanner.Logic
{
    public sealed class XmlOutputParser
    {
        public List<SellWish> SellWish { get; set; }
        public List<SellDirect> SellDirect { get; set; }
        public List<OrderList> OrderList { get; set; }
        public List<ProductionList> ProductionList { get; set; }
        public List<WorkingItemList> WorkingItemList { get; set; }
        public Boolean ProductioListSorted { get; set; }

        private static readonly XmlOutputParser instance = new XmlOutputParser();

        private XmlOutputParser()
        {
            SellWish = new List<SellWish>();
            SellDirect = new List<SellDirect>();
            OrderList = new List<OrderList>();
            ProductionList = new List<ProductionList>();
            WorkingItemList = new List<WorkingItemList>();
            ProductioListSorted = false;
        }

        public static XmlOutputParser Instance
        {
            get
            {
                return instance;
            }
        }

        public bool createOutputXml(String XmlFile)
        {
            if (XmlFile == null || XmlFile == "")
            {
                //throw new ArgumentException("XmlFile");
                return false;
            }

            XmlDocument doc = new XmlDocument();
            XmlNode myRoot;

            myRoot = doc.CreateElement("input");
            doc.AppendChild(myRoot);

            myRoot.AppendChild(getQualitycontrolNode(doc));
            myRoot.AppendChild(getSellwishNode(doc));
            myRoot.AppendChild(getSellDirectNode(doc));
            myRoot.AppendChild(getOrderListNode(doc));
            myRoot.AppendChild(getProductionListNode(doc));
            myRoot.AppendChild(getWorkingItemListNode(doc));

            doc.Save(XmlFile);

            return true;
        }

        public ProductionList getProductionItemById(int article)
        {
            foreach (var item in ProductionList)
            {
                if(item.Article == article)
                {
                    return item;
                }
            }
            return null;
        }

        private XmlNode getQualitycontrolNode(XmlDocument doc)
        {
            XmlNode myNode;
            XmlAttribute myAttribute;

            myNode = doc.CreateElement("qualitycontrol");

            myAttribute = doc.CreateAttribute("delay");
            myAttribute.InnerText = "0";
            myNode.Attributes.Append(myAttribute);

            myAttribute = doc.CreateAttribute("losequantity");
            myAttribute.InnerText = "0";
            myNode.Attributes.Append(myAttribute);

            myAttribute = doc.CreateAttribute("type");
            myAttribute.InnerText = "no";

            myNode.Attributes.Append(myAttribute);
            return myNode;
        }

        private XmlNode getSellwishNode(XmlDocument doc)
        {
            XmlNode myNode, myChildNode;
            XmlAttribute myAttribute;

            myNode = doc.CreateElement("sellwish");

            foreach (var sw in this.SellWish)
            {
                myChildNode = doc.CreateElement("item");

                myAttribute = doc.CreateAttribute("quantity");
                myAttribute.InnerText = sw.Quantity.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("article");
                myAttribute.InnerText = sw.Article.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myNode.AppendChild(myChildNode);
            }

            return myNode;
        }

        private XmlNode getSellDirectNode(XmlDocument doc)
        {
            XmlNode myNode, myChildNode;
            XmlAttribute myAttribute;

            myNode = doc.CreateElement("selldirect");

            foreach (var sd in this.SellDirect)
            {
                myChildNode = doc.CreateElement("item");

                myAttribute = doc.CreateAttribute("quantity");
                myAttribute.InnerText = sd.Quantity.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("article");
                myAttribute.InnerText = sd.Article.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("penalty");
                myAttribute.InnerText = sd.Penalty.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("price");
                myAttribute.InnerText = sd.Price.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myNode.AppendChild(myChildNode);
            }

            return myNode;
        }

        private XmlNode getOrderListNode(XmlDocument doc)
        {
            XmlNode myNode, myChildNode;
            XmlAttribute myAttribute;

            myNode = doc.CreateElement("orderlist");

            foreach (var ol in this.OrderList)
            {
                myChildNode = doc.CreateElement("order");

                myAttribute = doc.CreateAttribute("quantity");
                myAttribute.InnerText = ol.Quantity.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("article");
                myAttribute.InnerText = ol.Article.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("modus");
                myAttribute.InnerText = ol.Modus.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myNode.AppendChild(myChildNode);
            }

            return myNode;
        }

        private XmlNode getProductionListNode(XmlDocument doc)
        {
            XmlNode myNode, myChildNode;
            XmlAttribute myAttribute;

            myNode = doc.CreateElement("productionlist");

            foreach (var pl in this.ProductionList)
            {
                myChildNode = doc.CreateElement("production");

                myAttribute = doc.CreateAttribute("quantity");
                myAttribute.InnerText = pl.Quantity.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("article");
                myAttribute.InnerText = pl.Article.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myNode.AppendChild(myChildNode);
            }

            return myNode;
        }

        private XmlNode getWorkingItemListNode(XmlDocument doc)
        {
            XmlNode myNode, myChildNode;
            XmlAttribute myAttribute;

            myNode = doc.CreateElement("workingtimelist");

            foreach (var wt in this.WorkingItemList)
            {
                myChildNode = doc.CreateElement("workingtime");

                myAttribute = doc.CreateAttribute("overtime");
                myAttribute.InnerText = wt.WorkingOvertime.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("shift");
                myAttribute.InnerText = wt.Shift.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myAttribute = doc.CreateAttribute("station");
                myAttribute.InnerText = wt.Station.ToString();
                myChildNode.Attributes.Append(myAttribute);

                myNode.AppendChild(myChildNode);
            }

            return myNode;
        }

    }
}
