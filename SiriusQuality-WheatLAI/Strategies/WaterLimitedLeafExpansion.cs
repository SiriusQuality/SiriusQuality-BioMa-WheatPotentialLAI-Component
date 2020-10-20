

 //Author:pierre.martre pierre.martre@inra.fr
 //Institution:INRA
 //Author of revision: 
 //Date first release:9/28/2017
 //Date of revision:

using System;
using System.Collections.Generic;
using System.Xml;
using System.Linq;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Strategy;
using System.Reflection;
using VarInfo=CRA.ModelLayer.Core.VarInfo;
using Preconditions=CRA.ModelLayer.Core.Preconditions;


using SiriusQualityWheatLAI;
using CRA.AgroManagement;


//To make this project compile please add the reference to assembly: SiriusQuality-WheatLAI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: CRA.ModelLayer, Version=1.0.5212.29139, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: mscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: CRA.AgroManagement2014, Version=0.8.0.0, Culture=neutral, PublicKeyToken=null
//To make this project compile please add the reference to assembly: System, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
//To make this project compile please add the reference to assembly: System.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089;

namespace SiriusQualityWheatLAI.Strategies
{

	/// <summary>
	///Class WaterLimitedLeafExpansion
    /// 
    /// </summary>
	public class WaterLimitedLeafExpansion : IStrategySiriusQualityWheatLAI
	{

	#region Constructor

			public WaterLimitedLeafExpansion()
			{
				
				ModellingOptions mo0_0 = new ModellingOptions();
				//Parameters
				List<VarInfo> _parameters0_0 = new List<VarInfo>();
				VarInfo v1 = new VarInfo();
				 v1.DefaultValue = 0.35;
				 v1.Description = "Specific leaf Nitrogen at which LUE is null";
				 v1.Id = 0;
				 v1.MaxValue = 10;
				 v1.MinValue = 0;
				 v1.Name = "SLNmin";
				 v1.Size = 1;
				 v1.Units = "g(N)/m²(leaf)";
				 v1.URL = "";
				 v1.VarType = CRA.ModelLayer.Core.VarInfo.Type.STATE;
				 v1.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
				 _parameters0_0.Add(v1);
				mo0_0.Parameters=_parameters0_0;
				//Inputs
				List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd1 = new PropertyDescription();
				pd1.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd1.PropertyName = "cumulTTShoot";
				pd1.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot)).ValueType.TypeForCurrentValue;
				pd1.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot);
				_inputs0_0.Add(pd1);
				PropertyDescription pd2 = new PropertyDescription();
				pd2.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd2.PropertyName = "deltaTTShoot";
				pd2.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTShoot)).ValueType.TypeForCurrentValue;
				pd2.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTShoot);
				_inputs0_0.Add(pd2);
				PropertyDescription pd3 = new PropertyDescription();
				pd3.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd3.PropertyName = "deltaTTSenescence";
				pd3.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTSenescence)).ValueType.TypeForCurrentValue;
				pd3.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTSenescence);
				_inputs0_0.Add(pd3);
				PropertyDescription pd4 = new PropertyDescription();
				pd4.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd4.PropertyName = "DSF";
				pd4.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF)).ValueType.TypeForCurrentValue;
				pd4.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF);
				_inputs0_0.Add(pd4);
				PropertyDescription pd5 = new PropertyDescription();
				pd5.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd5.PropertyName = "DEF";
				pd5.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF)).ValueType.TypeForCurrentValue;
				pd5.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF);
				_inputs0_0.Add(pd5);
				PropertyDescription pd6 = new PropertyDescription();
				pd6.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd6.PropertyName = "GAI";
				pd6.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI)).ValueType.TypeForCurrentValue;
				pd6.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI);
				_inputs0_0.Add(pd6);
				PropertyDescription pd7 = new PropertyDescription();
				pd7.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd7.PropertyName = "TTGroLamina";
				pd7.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTGroLamina)).ValueType.TypeForCurrentValue;
				pd7.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTGroLamina);
				_inputs0_0.Add(pd7);
				PropertyDescription pd8 = new PropertyDescription();
				pd8.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd8.PropertyName = "State";
				pd8.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State)).ValueType.TypeForCurrentValue;
				pd8.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State);
				_inputs0_0.Add(pd8);
				PropertyDescription pd9 = new PropertyDescription();
				pd9.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd9.PropertyName = "PreviousState";
				pd9.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.PreviousState)).ValueType.TypeForCurrentValue;
				pd9.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.PreviousState);
				_inputs0_0.Add(pd9);
				PropertyDescription pd10 = new PropertyDescription();
				pd10.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd10.PropertyName = "TTsen";
				pd10.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen)).ValueType.TypeForCurrentValue;
				pd10.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen);
				_inputs0_0.Add(pd10);
				PropertyDescription pd11 = new PropertyDescription();
				pd11.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd11.PropertyName = "TTem";
				pd11.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem)).ValueType.TypeForCurrentValue;
				pd11.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem);
				_inputs0_0.Add(pd11);
				PropertyDescription pd12 = new PropertyDescription();
				pd12.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd12.PropertyName = "TTmat";
				pd12.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTmat)).ValueType.TypeForCurrentValue;
				pd12.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTmat);
				_inputs0_0.Add(pd12);
				PropertyDescription pd13 = new PropertyDescription();
				pd13.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd13.PropertyName = "laminaSpecificN";
				pd13.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.laminaSpecificN)).ValueType.TypeForCurrentValue;
				pd13.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.laminaSpecificN);
				_inputs0_0.Add(pd13);
				PropertyDescription pd14 = new PropertyDescription();
				pd14.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd14.PropertyName = "LaminaAI";
				pd14.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI)).ValueType.TypeForCurrentValue;
				pd14.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI);
				_inputs0_0.Add(pd14);
				PropertyDescription pd15 = new PropertyDescription();
				pd15.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd15.PropertyName = "SheathAI";
				pd15.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI)).ValueType.TypeForCurrentValue;
				pd15.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI);
				_inputs0_0.Add(pd15);
				PropertyDescription pd16 = new PropertyDescription();
				pd16.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd16.PropertyName = "MaxAI";
				pd16.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI)).ValueType.TypeForCurrentValue;
				pd16.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI);
				_inputs0_0.Add(pd16);
				PropertyDescription pd17 = new PropertyDescription();
				pd17.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd17.PropertyName = "isPrematurelyDying";
				pd17.PropertyType = (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying)).ValueType.TypeForCurrentValue;
				pd17.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying);
				_inputs0_0.Add(pd17);
				PropertyDescription pd18 = new PropertyDescription();
				pd18.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd18.PropertyName = "MaximumPotentialLaminaeAI";
				pd18.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialLaminaeAI)).ValueType.TypeForCurrentValue;
				pd18.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialLaminaeAI);
				_inputs0_0.Add(pd18);
				PropertyDescription pd19 = new PropertyDescription();
				pd19.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd19.PropertyName = "MaximumPotentialSheathAI";
				pd19.PropertyType = (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialSheathAI)).ValueType.TypeForCurrentValue;
				pd19.PropertyVarInfo =( SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialSheathAI);
				_inputs0_0.Add(pd19);
				mo0_0.Inputs=_inputs0_0;
				//Outputs
				List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
				PropertyDescription pd20 = new PropertyDescription();
				pd20.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd20.PropertyName = "incDeltaAreaLimitSF";
				pd20.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF)).ValueType.TypeForCurrentValue;
				pd20.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF);
				_outputs0_0.Add(pd20);
				PropertyDescription pd21 = new PropertyDescription();
				pd21.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd21.PropertyName = "WaterLimitedPotDeltaAIList";
				pd21.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList)).ValueType.TypeForCurrentValue;
				pd21.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList);
				_outputs0_0.Add(pd21);
				PropertyDescription pd22 = new PropertyDescription();
				pd22.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd22.PropertyName = "potentialIncDeltaArea";
				pd22.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea)).ValueType.TypeForCurrentValue;
				pd22.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea);
				_outputs0_0.Add(pd22);
				PropertyDescription pd23 = new PropertyDescription();
				pd23.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd23.PropertyName = "State";
				pd23.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State)).ValueType.TypeForCurrentValue;
				pd23.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.State);
				_outputs0_0.Add(pd23);
				PropertyDescription pd24 = new PropertyDescription();
				pd24.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLeafState);
				pd24.PropertyName = "isPrematurelyDying";
				pd24.PropertyType =  (( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying)).ValueType.TypeForCurrentValue;
				pd24.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying);
				_outputs0_0.Add(pd24);
				PropertyDescription pd25 = new PropertyDescription();
				pd25.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd25.PropertyName = "TT";
				pd25.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.TT)).ValueType.TypeForCurrentValue;
				pd25.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.TT);
				_outputs0_0.Add(pd25);
				PropertyDescription pd26 = new PropertyDescription();
				pd26.DomainClassType = typeof(SiriusQualityWheatLAI.WheatLAIState);
				pd26.PropertyName = "TTgroSheathList";
				pd26.PropertyType =  (( SiriusQualityWheatLAI.WheatLAIStateVarInfo.TTgroSheathList)).ValueType.TypeForCurrentValue;
				pd26.PropertyVarInfo =(  SiriusQualityWheatLAI.WheatLAIStateVarInfo.TTgroSheathList);
				_outputs0_0.Add(pd26);
				mo0_0.Outputs=_outputs0_0;
				//Associated strategies
				List<string> lAssStrat0_0 = new List<string>();
				mo0_0.AssociatedStrategies = lAssStrat0_0;
				//Adding the modeling options to the modeling options manager
				_modellingOptionsManager = new ModellingOptionsManager(mo0_0);
			
				SetStaticParametersVarInfoDefinitions();
				SetPublisherData();
					
			}

	#endregion

	#region Implementation of IAnnotatable

			/// <summary>
			/// Description of the model
			/// </summary>
			public string Description
			{
				get { return ""; }
			}
			
			/// <summary>
			/// URL to access the description of the model
			/// </summary>
			public string URL
			{
				get { return "http://biomamodelling.org"; }
			}
		

	#endregion
	
	#region Implementation of IStrategy

			/// <summary>
			/// Domain of the model.
			/// </summary>
			public string Domain
			{
				get {  return "Crop"; }
			}

			/// <summary>
			/// Type of the model.
			/// </summary>
			public string ModelType
			{
				get { return ""; }
			}

			/// <summary>
			/// Declare if the strategy is a ContextStrategy, that is, it contains logic to select a strategy at run time. 
			/// </summary>
			public bool IsContext
			{
					get { return  false; }
			}

			/// <summary>
			/// Timestep to be used with this strategy
			/// </summary>
			public IList<int> TimeStep
			{
				get
				{
					IList<int> ts = new List<int>();
					
					return ts;
				}
			}
	
	
	#region Publisher Data

			private PublisherData _pd;
			private  void SetPublisherData()
			{
					// Set publishers' data
					
				_pd = new CRA.ModelLayer.MetadataTypes.PublisherData();
				_pd.Add("Creator", "pierre.martre@inra.fr");
				_pd.Add("Date", "9/28/2017");
				_pd.Add("Publisher", "INRA");
			}

			public PublisherData PublisherData
			{
				get { return _pd; }
			}

	#endregion

	#region ModellingOptionsManager

			private ModellingOptionsManager _modellingOptionsManager;
			
			public ModellingOptionsManager ModellingOptionsManager
			{
				get { return _modellingOptionsManager; }            
			}

	#endregion

			/// <summary>
			/// Return the types of the domain classes used by the strategy
			/// </summary>
			/// <returns></returns>
			public IEnumerable<Type> GetStrategyDomainClassesTypes()
			{
				return new List<Type>() {  typeof(SiriusQualityWheatLAI.WheatLAIState),typeof(SiriusQualityWheatLAI.WheatLeafState),typeof(SiriusQualityWheatLAI.WheatLeafState),typeof(CRA.AgroManagement.ActEvents) };
			}

	#endregion

    #region Instances of the parameters
			
			// Getter and setters for the value of the parameters of the strategy. The actual parameters are stored into the ModelingOptionsManager of the strategy.

			
			public Double SLNmin
			{ 
				get {
						VarInfo vi= _modellingOptionsManager.GetParameterByName("SLNmin");
						if (vi != null && vi.CurrentValue!=null) return (Double)vi.CurrentValue ;
						else throw new Exception("Parameter 'SLNmin' not found (or found null) in strategy 'WaterLimitedLeafExpansion'");
				 } set {
							VarInfo vi = _modellingOptionsManager.GetParameterByName("SLNmin");
							if (vi != null)  vi.CurrentValue=value;
						else throw new Exception("Parameter 'SLNmin' not found in strategy 'WaterLimitedLeafExpansion'");
				}
			}

			// Getter and setters for the value of the parameters of a composite strategy
			

	#endregion		

	
	#region Parameters initialization method
			
            /// <summary>
            /// Set parameter(s) current values to the default value
            /// </summary>
            public void SetParametersDefaultValue()
            {
				_modellingOptionsManager.SetParametersDefaultValue();
				 

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section5
					//Code written below will not be overwritten by a future code generation

					//Custom initialization of the parameter. E.g. initialization of the array dimensions of array parameters

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section5 
            }

	#endregion		

	#region Static parameters VarInfo definition

			// Define the properties of the static VarInfo of the parameters
			private static void SetStaticParametersVarInfoDefinitions()
			{                                
                SLNminVarInfo.Name = "SLNmin";
				SLNminVarInfo.Description =" Specific leaf Nitrogen at which LUE is null";
				SLNminVarInfo.MaxValue = 10;
				SLNminVarInfo.MinValue = 0;
				SLNminVarInfo.DefaultValue = 0.35;
				SLNminVarInfo.Units = "g(N)/m²(leaf)";
				SLNminVarInfo.ValueType = CRA.ModelLayer.Core.VarInfoValueTypes.GetInstanceForName("Double");

				
       
			}

			//Parameters static VarInfo list 
			
				private static VarInfo _SLNminVarInfo= new VarInfo();
				/// <summary> 
				///SLNmin VarInfo definition
				/// </summary>
				public static VarInfo SLNminVarInfo
				{
					get { return _SLNminVarInfo; }
				}					
			
			//Parameters static VarInfo list of the composite class
						

	#endregion
	
	#region pre/post conditions management		

		    /// <summary>
			/// Test to verify the postconditions
			/// </summary>
			public string TestPostConditions(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1, string callID)
			{
				try
				{
					//Set current values of the outputs to the static VarInfo representing the output properties of the domain classes				
					
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF.CurrentValue=wheatlaistate.incDeltaAreaLimitSF;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList.CurrentValue=wheatlaistate.WaterLimitedPotDeltaAIList;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea.CurrentValue=wheatlaistate.potentialIncDeltaArea;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.State.CurrentValue=wheatleafstate.State;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying.CurrentValue=wheatleafstate.isPrematurelyDying;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.TT.CurrentValue=wheatlaistate.TT;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.TTgroSheathList.CurrentValue=wheatlaistate.TTgroSheathList;
					
					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();            
					
					
					RangeBasedCondition r20 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF);
					if(r20.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.incDeltaAreaLimitSF.ValueType)){prc.AddCondition(r20);}
					RangeBasedCondition r21 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList);
					if(r21.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.WaterLimitedPotDeltaAIList.ValueType)){prc.AddCondition(r21);}
					RangeBasedCondition r22 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea);
					if(r22.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.potentialIncDeltaArea.ValueType)){prc.AddCondition(r22);}
					RangeBasedCondition r23 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.State);
					if(r23.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State.ValueType)){prc.AddCondition(r23);}
					RangeBasedCondition r24 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying);
					if(r24.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying.ValueType)){prc.AddCondition(r24);}
					RangeBasedCondition r25 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.TT);
					if(r25.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.TT.ValueType)){prc.AddCondition(r25);}
					RangeBasedCondition r26 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.TTgroSheathList);
					if(r26.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.TTgroSheathList.ValueType)){prc.AddCondition(r26);}

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section4
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section4 

					//Get the evaluation of postconditions
					string postConditionsResult =pre.VerifyPostconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(postConditionsResult)) { pre.TestsOut(postConditionsResult, true, "PostConditions errors in component SiriusQualityWheatLAI.Strategies, strategy " + this.GetType().Name ); }
					return postConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1001,	"Strategy: " + this.GetType().Name + " - Unhandled exception running post-conditions");

					string msg = "Component SiriusQualityWheatLAI.Strategies, " + this.GetType().Name + ": Unhandled exception running post-condition test. ";
					throw new Exception(msg, exception);
				}
			}

			/// <summary>
			/// Test to verify the preconditions
			/// </summary>
			public string TestPreConditions(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1, string callID)
			{
				try
				{
					//Set current values of the inputs to the static VarInfo representing the input properties of the domain classes				
					
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot.CurrentValue=wheatlaistate.cumulTTShoot;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTShoot.CurrentValue=wheatlaistate.deltaTTShoot;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTSenescence.CurrentValue=wheatlaistate.deltaTTSenescence;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF.CurrentValue=wheatlaistate.DSF;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF.CurrentValue=wheatlaistate.DEF;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI.CurrentValue=wheatleafstate.GAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTGroLamina.CurrentValue=wheatleafstate.TTGroLamina;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.State.CurrentValue=wheatleafstate.State;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.PreviousState.CurrentValue=wheatleafstate.PreviousState;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen.CurrentValue=wheatleafstate.TTsen;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem.CurrentValue=wheatleafstate.TTem;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTmat.CurrentValue=wheatleafstate.TTmat;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.laminaSpecificN.CurrentValue=wheatleafstate.laminaSpecificN;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI.CurrentValue=wheatleafstate.LaminaAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI.CurrentValue=wheatleafstate.SheathAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI.CurrentValue=wheatleafstate.MaxAI;
					SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying.CurrentValue=wheatleafstate.isPrematurelyDying;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialLaminaeAI.CurrentValue=wheatlaistate.MaximumPotentialLaminaeAI;
					SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialSheathAI.CurrentValue=wheatlaistate.MaximumPotentialSheathAI;

					//Create the collection of the conditions to test
					ConditionsCollection prc = new ConditionsCollection();
					Preconditions pre = new Preconditions();
            
					
					RangeBasedCondition r1 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot);
					if(r1.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.cumulTTShoot.ValueType)){prc.AddCondition(r1);}
					RangeBasedCondition r2 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTShoot);
					if(r2.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTShoot.ValueType)){prc.AddCondition(r2);}
					RangeBasedCondition r3 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTSenescence);
					if(r3.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.deltaTTSenescence.ValueType)){prc.AddCondition(r3);}
					RangeBasedCondition r4 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF);
					if(r4.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DSF.ValueType)){prc.AddCondition(r4);}
					RangeBasedCondition r5 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF);
					if(r5.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.DEF.ValueType)){prc.AddCondition(r5);}
					RangeBasedCondition r6 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI);
					if(r6.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.GAI.ValueType)){prc.AddCondition(r6);}
					RangeBasedCondition r7 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTGroLamina);
					if(r7.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTGroLamina.ValueType)){prc.AddCondition(r7);}
					RangeBasedCondition r8 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.State);
					if(r8.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.State.ValueType)){prc.AddCondition(r8);}
					RangeBasedCondition r9 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.PreviousState);
					if(r9.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.PreviousState.ValueType)){prc.AddCondition(r9);}
					RangeBasedCondition r10 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen);
					if(r10.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTsen.ValueType)){prc.AddCondition(r10);}
					RangeBasedCondition r11 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem);
					if(r11.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTem.ValueType)){prc.AddCondition(r11);}
					RangeBasedCondition r12 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTmat);
					if(r12.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.TTmat.ValueType)){prc.AddCondition(r12);}
					RangeBasedCondition r13 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.laminaSpecificN);
					if(r13.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.laminaSpecificN.ValueType)){prc.AddCondition(r13);}
					RangeBasedCondition r14 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI);
					if(r14.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.LaminaAI.ValueType)){prc.AddCondition(r14);}
					RangeBasedCondition r15 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI);
					if(r15.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.SheathAI.ValueType)){prc.AddCondition(r15);}
					RangeBasedCondition r16 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI);
					if(r16.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.MaxAI.ValueType)){prc.AddCondition(r16);}
					RangeBasedCondition r17 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying);
					if(r17.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLeafStateVarInfo.isPrematurelyDying.ValueType)){prc.AddCondition(r17);}
					RangeBasedCondition r18 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialLaminaeAI);
					if(r18.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialLaminaeAI.ValueType)){prc.AddCondition(r18);}
					RangeBasedCondition r19 = new RangeBasedCondition(SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialSheathAI);
					if(r19.ApplicableVarInfoValueTypes.Contains( SiriusQualityWheatLAI.WheatLAIStateVarInfo.MaximumPotentialSheathAI.ValueType)){prc.AddCondition(r19);}
					prc.AddCondition(new RangeBasedCondition(_modellingOptionsManager.GetParameterByName("SLNmin")));

					

					//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section3
					//Code written below will not be overwritten by a future code generation

        

					//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
					//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section3 
								
					//Get the evaluation of preconditions;					
					string preConditionsResult =pre.VerifyPreconditions(prc, callID);
					//if we have errors, send it to the configured output 
					if(!string.IsNullOrEmpty(preConditionsResult)) { pre.TestsOut(preConditionsResult, true, "PreConditions errors in component SiriusQualityWheatLAI.Strategies, strategy " + this.GetType().Name ); }
					return preConditionsResult;
				}
				catch (Exception exception)
				{
					//Uncomment the next line to use the trace
					//	TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,"Strategy: " + this.GetType().Name + " - Unhandled exception running pre-conditions");

					string msg = "Component SiriusQualityWheatLAI.Strategies, " + this.GetType().Name + ": Unhandled exception running pre-condition test. ";
					throw new Exception(msg, exception);
				}
			}

		
	#endregion
		


	#region Model

		 	/// <summary>
			/// Run the strategy to calculate the outputs. In case of error during the execution, the preconditions tests are executed.
			/// </summary>
			public void Estimate(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1,CRA.AgroManagement.ActEvents actevents)
			{
            try
            {
                CalculateModel(wheatlaistate, wheatleafstate, wheatleafstate1, actevents);

                //Uncomment the next line to use the trace
                //TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1005,"Strategy: " + this.GetType().Name + " - Model executed");
            }
            catch (Exception exception)
            {
                //Uncomment the next line to use the trace
                //TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1003,		"Strategy: " + this.GetType().Name + " - Unhandled exception running model");

                string msg = "Error in component SiriusQualityWheatLAI.Strategies, strategy: " + this.GetType().Name + ": Unhandled exception running model. " + exception.GetType().FullName + " - " + exception.Message;
                throw new Exception(msg, exception);
            }
}

		

			private void CalculateModel(SiriusQualityWheatLAI.WheatLAIState wheatlaistate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate,SiriusQualityWheatLAI.WheatLeafState wheatleafstate1,CRA.AgroManagement.ActEvents actevents)
			{				
				

				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section1
				//Code written below will not be overwritten by a future code generation
                //update the size of the lists
                for (int i = 0; i < wheatleafstate.GAI.Count; i++)
                {
                    //if a new leaf has appeared
                    if (i >= wheatlaistate.WaterLimitedPotDeltaAIList.Count)
                    {
                        wheatlaistate.WaterLimitedPotDeltaAIList.Add(0);
                        wheatlaistate.TTgroSheathList.Add(wheatleafstate.TTGroLamina[i] * wheatlaistate.MaximumPotentialSheathAI[i] / wheatlaistate.MaximumPotentialLaminaeAI[i]);
                        wheatlaistate.TT.Add(wheatlaistate.cumulTTShoot - wheatlaistate.deltaTTShoot);
                    }
                }

                CalculateNewStates(wheatlaistate,wheatleafstate,wheatleafstate1);

                // calculate potential delta area
                CalculatePotIncDeltaAI(wheatlaistate, wheatleafstate, wheatleafstate1);
        

				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section1 
			}

				

	#endregion


				//GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section2
				//Code written below will not be overwritten by a future code generation

            /// <summary>Calculate potential delta area index of the day (either growth or senescence)</summary>
            /// <param name="potentialIncDeltaArea">Potential delta area index increment of the day</param>
            private void CalculatePotIncDeltaAI(SiriusQualityWheatLAI.WheatLAIState wheatlaistate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate1)
            {



                wheatlaistate.potentialIncDeltaArea = 0;
                for (int i = 0; i < wheatleafstate.GAI.Count; i++)
                {
                    CalculateWaterLimitedPotentialDeltaArea(wheatlaistate, wheatleafstate, wheatleafstate1, i);
                    var potDelta = wheatlaistate.WaterLimitedPotDeltaAIList[i];
                    if (potDelta > 0) wheatlaistate.potentialIncDeltaArea += potDelta;
                }

                wheatlaistate.incDeltaAreaLimitSF = wheatlaistate.potentialIncDeltaArea * wheatlaistate.DEF;

            }

            private void CalculateWaterLimitedPotentialDeltaArea(SiriusQualityWheatLAI.WheatLAIState wheatlaistate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate1, int i)
            {
                wheatlaistate.WaterLimitedPotDeltaAIList[i] = 0;

                if (wheatleafstate.State[i] >= 2)
                {
                    wheatlaistate.WaterLimitedPotDeltaAIList[i] = Math.Max(-wheatleafstate.MaxAI[i] * (wheatlaistate.deltaTTSenescence * wheatlaistate.DSF) / wheatleafstate.TTsen[i], -(wheatleafstate.LaminaAI[i] + wheatleafstate.SheathAI[i]));
                }
                else if (wheatleafstate.State[i] == 0 && wheatleafstate.isPrematurelyDying[i] == 0)
                {
                    if ((wheatlaistate.cumulTTShoot - wheatleafstate.TTem[i]) < wheatleafstate.TTGroLamina[i]) //IsLeafLaminaeGrowing
                    {
                        wheatlaistate.WaterLimitedPotDeltaAIList[i] = Math.Min(wheatlaistate.MaximumPotentialLaminaeAI[i] * wheatlaistate.deltaTTShoot / wheatleafstate.TTGroLamina[i], Math.Max(0, wheatlaistate.MaximumPotentialLaminaeAI[i] - wheatleafstate.LaminaAI[i]));
                    }
                    else if (wheatlaistate.TTgroSheathList[i] > 0)
                    {
                        wheatlaistate.WaterLimitedPotDeltaAIList[i] = Math.Min(wheatlaistate.MaximumPotentialSheathAI[i] * wheatlaistate.deltaTTShoot / wheatlaistate.TTgroSheathList[i], Math.Max(0, wheatlaistate.MaximumPotentialSheathAI[i] - wheatleafstate.SheathAI[i]));
                    }
                }
            }

            /// <summary>Update all leaf state </summary>
            private void CalculateNewStates(SiriusQualityWheatLAI.WheatLAIState wheatlaistate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate1)
            {

                wheatleafstate1.State = new List<int>();
                wheatleafstate.PreviousState = new List<int>();

                for (int i = 0; i < wheatleafstate.GAI.Count; i++)
                {
                    double TTgro = wheatleafstate.TTGroLamina[i] + wheatlaistate.TTgroSheathList[i];
                    CalculateNewLeafLayerState(wheatlaistate,wheatleafstate,wheatleafstate1, i, wheatleafstate.GAI[i], wheatleafstate.TTem[i], TTgro, wheatleafstate.TTmat[i], wheatleafstate.TTsen[i], wheatleafstate.laminaSpecificN[i]);
                }
            }

            private void CalculateNewLeafLayerState(SiriusQualityWheatLAI.WheatLAIState wheatlaistate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate, SiriusQualityWheatLAI.WheatLeafState wheatleafstate1, int leafIndex, double GAI, double TTem, double TTgro, double TTmat, double TTsen, double leafLaminaSpecificN)
            {


                wheatleafstate1.State.Add(wheatleafstate.State[leafIndex]);
                wheatleafstate.PreviousState.Add(wheatleafstate1.State[leafIndex]);

                switch (wheatleafstate.State[leafIndex])
                {
                    case 1:
                    case 2:  wheatlaistate.TT[leafIndex] += wheatlaistate.deltaTTSenescence * wheatlaistate.DSF; break; 
                    default: wheatlaistate.TT[leafIndex] += wheatlaistate.deltaTTShoot; break;
                }
                if (GAI <= 0 && wheatleafstate.State[leafIndex] >= 1 && wheatleafstate.State[leafIndex] != 3)
                {
                    wheatleafstate1.State[leafIndex] = 3;
                }
                else if (GAI > 0)
                {
                    if (wheatleafstate.isPrematurelyDying[leafIndex]==0)
                    {
                        if (wheatlaistate.TT[leafIndex] <= TTem + TTgro)
                        {
                            wheatleafstate1.State[leafIndex] = 0;
                        }
                        else if (wheatlaistate.TT[leafIndex] < TTem + TTgro + TTmat)
                        {
                            wheatleafstate1.State[leafIndex] = 1;
                        }
                        else if (wheatlaistate.TT[leafIndex] < TTem + TTgro + TTmat + TTsen || GAI > 0)
                        {
                            wheatleafstate1.State[leafIndex] = 2;
                        }
                        else
                        {
                            wheatleafstate1.State[leafIndex] = 3;
                        }
                        if (leafLaminaSpecificN <= SLNmin)
                        {
                            wheatleafstate1.isPrematurelyDying[leafIndex] = 1;
                            wheatleafstate1.State[leafIndex] = 2;
                        }
                    }
                    else
                    {
                        wheatleafstate1.State[leafIndex] = 2;
                    }
                }

                wheatleafstate.State[leafIndex] = wheatleafstate1.State[leafIndex];
                wheatleafstate.isPrematurelyDying[leafIndex] = wheatleafstate1.isPrematurelyDying[leafIndex];
            }


				//End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
				//PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section2 
	}
}
