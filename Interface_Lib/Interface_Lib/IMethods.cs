using System.Collections.Generic;

namespace Interface_Lib
{
    /// <summary>
    /// IMethods is an interface which is used to declare 4 methods which we shall implement in a class of another .dll
    /// </summary>
    public interface IMethods
    {
        /// <summary>
        /// This method will be used to retrieve data from XML database.
        /// </summary>
        /// <returns>It returns a List of type Instrument</returns>
        public List<Instruments> getInstruments();


        /// <summary>
        /// The addInstrument methods is declared with 3 parameters. This method will add instruments to XML database.
        /// </summary>
        /// <param name="_name"> It respresents instrument name</param>
        /// <param name="_user"> It represents user name</param>
        /// <param name="_project">It represents project name</param>
        public void addInstrument(Instruments newInst);


        /// <summary>
        /// This method is declared with 1 parameter only. This method will delete specified instrument.
        /// </summary>
        /// <param name="_name">It represents the instrument name which you want to delete</param>
        /// 
        public void deleteInstrument(string _name);


        /// <summary>
        /// This method is declared with 2 parameters. This method is supposed to update specified instrument with new instrument data
        /// </summary>
        /// <param name="_toUpdateInstr">It represents the instrument name which you want to update</param>
        /// <param name="ins">It represents the Instrument object which you want to put instead of previous parameter</param>
        public void updateInstrument(string _toUpdateInstr, Instruments ins);
        
    }
}
