using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SiriusQualityWheatLAI;

namespace SiriusQuality_SiriusQuality_WheatLAIConsole
{
    class WheatLAIWrapper
    {

        #region Ouptuts

        public List<LeafState> getLeafStateList(){ return GetStateListWheat(); }


        public List<LeafState> getLeafPreviousStateList(){return GetPreviousStateListWheat();}


        public List<int> getIsPrematurelyDyingList(){return wheatLeafstate_.isPrematurelyDying; }

        public double getIncDeltaAreaLimitSF(){return wheatLaistate_.incDeltaAreaLimitSF; }

        public double getPotentialIncDeltaArea(){return wheatLaistate_.potentialIncDeltaArea; }


        public double DEF{get{return wheatLaistate_.DEF;}}

        public double DSF{get{return wheatLaistate_.DSF;}}


        public double getWaterLimitedPotDeltaAI(int i)
        {
                if (i < wheatLaistate_.WaterLimitedPotDeltaAIList.Count)
                {
                    return wheatLaistate_.WaterLimitedPotDeltaAIList[i];
                }
                else
                {
                    return -1;
                }

        }

        private int previousIndex = -1;


        #endregion

        #region Parameters
        //See "Documentation\SQ-Phenology: BioMA-SiriusQuality component of Wheat potential LAI" document Table A2 for definitions
        //Exemple of parameter set for spring wheat and Yecora Rojo variety.

            double AreaPL=27.378;
            double AreaSL=9.0;
            double AreaSS=1.83;
            double LowerFPAWexp=0.1;
            double LowerFPAWsen=0.1;
            double LowerVPD=15.0;
            double MaxDSF=4.5;
            double NLL=5.69;
            double PexpL=1.1;
            double RatioFLPL=1.06;
            double SLNmin=0.35;
            double UpperFPAWexp=0.5;
            double UpperFPAWsen=0.4;
            double UpperVPD=45.0;
            double PlagLL=8.0;
            double PlagSL=4.0;
            double PsenLL=5.0;
            double PsenSL=3.3;

        #endregion

        #region constructors 

            public WheatLAIWrapper()
            {
                wheatLAI_ = new SiriusQualityWheatLAI.Strategies.WheatLAI();
                wheatLaistate_ = new SiriusQualityWheatLAI.WheatLAIState();
                wheatLeafstate_ = new SiriusQualityWheatLAI.WheatLeafState();
                wheatLeafstate1_ = new SiriusQualityWheatLAI.WheatLeafState();

                loadParametersWheat();

            }


            public WheatLAIWrapper(WheatLAIWrapper toCopy)
            {

                wheatLaistate_ = (toCopy.wheatLaistate_ != null) ? new SiriusQualityWheatLAI.WheatLAIState(toCopy.wheatLaistate_) : null;
                wheatLeafstate_ = (toCopy.wheatLeafstate_ != null) ? new SiriusQualityWheatLAI.WheatLeafState(toCopy.wheatLeafstate_) : null;
                wheatLeafstate1_ = (toCopy.wheatLeafstate1_ != null) ? new SiriusQualityWheatLAI.WheatLeafState(toCopy.wheatLeafstate1_) : null;
                wheatLAI_ = (toCopy.wheatLAI_ != null) ? new SiriusQualityWheatLAI.Strategies.WheatLAI(toCopy.wheatLAI_) : null;

            }

         #endregion

        #region Estimate function

            public void Estimate(bool newLeafHasAppeared, int roundedFinalNumber, double finalLeafNumber, double leafNumber,
                                 int newLeafLastPhytoNum, int newLeafindex,double FPAW, bool isPotentialLAI, double cumulTTShoot, double deltaTTShoot, double deltaTTSenescence, List<LeafLayer> All, double VPDairCanopy,
                                  List<double> tilleringProfile, List<double> leafTillerNumberArray)
            {

                    //Valorize inputs
                    wheatLaistate_.newLeafHasAppeared = newLeafHasAppeared ? 1 : 0;
                    wheatLaistate_.roundedFinalLeafNumber = roundedFinalNumber;
                    wheatLaistate_.finalLeafNumber = finalLeafNumber;
                    wheatLaistate_.leafNumber = leafNumber;
                    wheatLaistate_.FPAW = FPAW;
                    wheatLaistate_.isPotentialLAI = isPotentialLAI ? 1 : 0;
                    wheatLaistate_.cumulTTShoot = cumulTTShoot;
                    wheatLaistate_.deltaTTShoot = deltaTTShoot;
                    wheatLaistate_.deltaTTSenescence = deltaTTSenescence;
                    wheatLaistate_.VPDairCanopy = VPDairCanopy;
                    wheatLaistate_.tilleringProfile = tilleringProfile;
                    wheatLaistate_.leafTillerNumberArray = leafTillerNumberArray;
                    wheatLaistate_.phytonum = newLeafLastPhytoNum;
                    wheatLaistate_.index = newLeafindex;
                    wheatLaistate_.previousIndex = previousIndex;
                    previousIndex = newLeafindex;

                    //Valorize the leaf layer states of the component from the leaf Layer class
                    FillIntputLayersWheat(All);

                    //Call the estimate function of the composite class
                    wheatLAI_.Estimate(wheatLaistate_, wheatLeafstate_, wheatLeafstate1_, null);

                    //Fill the objects of the leafLayer Class with the content of leaf layers of the component
                    FillOutputLayersWheat(All);

            }

        #endregion

        #region Utilities

        #region LoadParameters

            private void loadParametersWheat()
        {
            wheatLAI_.AreaPL = AreaPL;
            wheatLAI_.AreaSL = AreaSL;
            wheatLAI_.AreaSS = AreaSS;
            wheatLAI_.LowerFPAWexp = LowerFPAWexp;
            wheatLAI_.LowerFPAWsen = LowerFPAWsen;
            wheatLAI_.LowerVPD = LowerVPD;
            wheatLAI_.MaxDSF = MaxDSF;
            wheatLAI_.NLL = NLL;
            wheatLAI_.PexpL = PexpL;
            wheatLAI_.RatioFLPL = RatioFLPL;
            wheatLAI_.SLNmin = SLNmin;
            wheatLAI_.UpperFPAWexp = UpperFPAWexp;
            wheatLAI_.UpperFPAWsen = UpperFPAWsen;
            wheatLAI_.UpperVPD = UpperVPD;
            wheatLAI_.PlagLL = PlagLL;
            wheatLAI_.PlagSL = PlagSL;
            wheatLAI_.PsenLL = PsenLL;
            wheatLAI_.PsenSL = PsenSL;
        }
        #endregion

        #region Output state convertors

        private List<LeafState> GetStateListWheat()
        {

            List<LeafState> list = new List<LeafState>();

            for (int ilayer = 0; ilayer < wheatLeafstate1_.State.Count; ilayer++)
            {

                switch (wheatLeafstate1_.State[ilayer])
                {
                    case 0:
                        list.Add(LeafState.Growing);
                        break;
                    case 1:
                        list.Add(LeafState.Mature);
                        break;
                    case 2:
                        list.Add(LeafState.Senescing);
                        break;
                    case 3:
                        list.Add(LeafState.Dead);
                        break;
                }
            }


            return list;
        }

        private List<LeafState> GetPreviousStateListWheat()
        {

            List<LeafState> list = new List<LeafState>();

            for (int ilayer = 0; ilayer < wheatLeafstate_.PreviousState.Count; ilayer++)
            {

                switch (wheatLeafstate_.PreviousState[ilayer])
                {
                    case 0:
                        list.Add(LeafState.Growing);
                        break;
                    case 1:
                        list.Add(LeafState.Mature);
                        break;
                    case 2:
                        list.Add(LeafState.Senescing);
                        break;
                    case 3:
                        list.Add(LeafState.Dead);
                        break;
                }
            }


            return list;
        }

        #endregion

        #region Connection with Leaf layer object

        private void FillIntputLayersWheat(List<LeafLayer> All)
        {

            for (int ilayer = 0; ilayer < All.Count; ilayer++)
            {

                switch (All[ilayer].State)
                {
                    case LeafState.Growing:
                        wheatLeafstate_.State[ilayer] = 0;
                        break;
                    case LeafState.Mature:
                        wheatLeafstate_.State[ilayer] = 1;
                        break;
                    case LeafState.Senescing:
                        wheatLeafstate_.State[ilayer] = 2;
                        break;
                    case LeafState.Dead:
                        wheatLeafstate_.State[ilayer] = 3;
                        break;
                }
                wheatLeafstate_.GAI[ilayer] = All[ilayer].GAI;
                wheatLeafstate_.MaxAI[ilayer] = All[ilayer].MaxAI;
                wheatLeafstate_.Phyllochron[ilayer] = All[ilayer].LayerPhyllochron;
                wheatLeafstate_.TTGroLamina[ilayer] = All[ilayer].TTgroLamina;
                wheatLeafstate_.laminaSpecificN[ilayer] = All[ilayer].LaminaSpecificN;
                wheatLeafstate_.LaminaAI[ilayer] = All[ilayer].laminaAI;
                wheatLeafstate_.SheathAI[ilayer] = All[ilayer].sheathAI;
                wheatLeafstate_.isPrematurelyDying[ilayer] = All[ilayer].IsPrematurelyDying ? 1 : 0;
                wheatLeafstate_.TTem[ilayer] = All[ilayer].TTem;

                if (All[ilayer].IsSmallPhytomer == true) wheatLeafstate_.isSmallPhytomer[ilayer] = 1;
                else wheatLeafstate_.isSmallPhytomer[ilayer] = 0;


            }
        }

        private void FillOutputLayersWheat(List<LeafLayer> All)
        {
            for (int ilayer = 0; ilayer < wheatLeafstate_.State.Count; ilayer++)
            {

                switch (wheatLeafstate_.State[ilayer])
                {
                    case 0:
                        All[ilayer].setState(LeafState.Growing);
                        break;
                    case 1:
                        All[ilayer].setState(LeafState.Mature);
                        break;
                    case 2:
                        All[ilayer].setState(LeafState.Senescing);
                        break;
                    case 3:
                        All[ilayer].setState(LeafState.Dead);
                        break;
                }


                All[ilayer].TTsen = wheatLeafstate_.TTsen[ilayer];
                All[ilayer].TTmat = wheatLeafstate_.TTmat[ilayer];
                All[ilayer].TTgroLamina = wheatLeafstate_.TTGroLamina[ilayer];

                if (wheatLeafstate_.isSmallPhytomer[ilayer] == 1) All[ilayer].IsSmallPhytomer = true;
                else All[ilayer].IsSmallPhytomer = false;

                All[ilayer].setPrematurelyDying(wheatLeafstate1_.isPrematurelyDying[ilayer]);


            }

        }


        #endregion

        #region create a conmponent leaf layer

        public void CreateLeafLayerLAIComponentWheat()
        {

            wheatLeafstate_.State.Add(0);
            wheatLeafstate_.isPrematurelyDying.Add(0);
            wheatLeafstate_.isSmallPhytomer.Add(0);
            wheatLeafstate_.GAI.Add(0.0);
            wheatLeafstate_.PreviousState.Add(0);
            wheatLeafstate_.TTsen.Add(0.0);
            wheatLeafstate_.TTmat.Add(0.0);
            wheatLeafstate_.TTem.Add(0.0);
            wheatLeafstate_.TTGroLamina.Add(0.0);
            wheatLeafstate_.MaxAI.Add(0.0);
            wheatLeafstate_.Phyllochron.Add(0.0);
            wheatLeafstate_.laminaSpecificN.Add(0.0);
            wheatLeafstate_.LaminaAI.Add(0.0);
            wheatLeafstate_.SheathAI.Add(0.0);


            wheatLeafstate1_.State.Add(0);
            wheatLeafstate1_.isPrematurelyDying.Add(0);


        }

        #endregion

        #endregion

        #region Intantiation

        //Composite strategy instantiation
        private SiriusQualityWheatLAI.Strategies.WheatLAI wheatLAI_;

        //Domain class instantiation

        //LAI state of the day
        private SiriusQualityWheatLAI.WheatLAIState wheatLaistate_;
        
        //Layer State of the day before
        private SiriusQualityWheatLAI.WheatLeafState wheatLeafstate_;

        //Layer State of the day
        private SiriusQualityWheatLAI.WheatLeafState wheatLeafstate1_;




        #endregion



    }
}
