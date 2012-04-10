namespace WHC.Pager.Entity
{
    using System;
    using System.Xml.Serialization;

    [Serializable]
    public class PagerInfo
    {
        private int currenetPageIndex;
        private int pageSize;
        private int recordCount;

        [XmlElement(ElementName="CurrenetPageIndex")]
        public int CurrenetPageIndex
        {
            get
            {
                return this.currenetPageIndex;
            }
            set
            {
                this.currenetPageIndex = value;
            }
        }

        [XmlElement(ElementName="PageSize")]
        public int PageSize
        {
            get
            {
                return this.pageSize;
            }
            set
            {
                this.pageSize = value;
            }
        }

        [XmlElement(ElementName="RecordCount")]
        public int RecordCount
        {
            get
            {
                return this.recordCount;
            }
            set
            {
                this.recordCount = value;
            }
        }
    }
}

