using System;
using UIKit;

namespace Random
{
    public partial class ViewController : UIViewController
    {
        partial void RNValueChanged(UITextField sender)
        {
            this.RN.Copy();
            updateErrorTextbox("Random Number Copied");
        }

	void updateTextBoxnadLabelHiddenProperty(
		bool normalMeanLabel,
		bool normalVarianceLabel,
		bool normalMeanTextbox,
		bool normalVarianceTextbox,
		bool exponentialParameterLabel,
		bool exponentialParameterTextbox,
		bool weibullLabel)
	{
		this.normalMeanLabel.Hidden = normalMeanLabel;
                this.normalVarianceLabel.Hidden = normalVarianceLabel;
                this.normalMeanTextbox.Hidden = normalMeanTextbox;
                this.normalVarianceTextbox.Hidden = normalVarianceTextbox;
                this.exponentialParameterLabel.Hidden = exponentialParameterLabel;
                this.exponentialParameterTextbox.Hidden = exponentialParameterTextbox;
                this.weibullLabel.Hidden = weibullLabel;
	}

        partial void selectStepper1(UISegmentedControl sender)
        {
            nint caseSwitch = this.stepper1.SelectedSegment;

            switch (caseSwitch)
            {
                case 0:
		    this.BeginInvokeOnMainThread(new Action(() => { 
		    	updateTextBoxnadLabelHiddenProperty(true,true,true,true,true,true,true);
	            }));
                    break;
                case 1:
		    this.BeginInvokeOnMainThread(new Action(() => { 
		    	updateTextBoxnadLabelHiddenProperty(false,false,false,false,true,true,true);
	            }));
                    break;
                case 2:
		    this.BeginInvokeOnMainThread(new Action(() => { 
		    	updateTextBoxnadLabelHiddenProperty(true,true,true,true,false,false,true);
	            }));
                    break;
                case 3:
		    this.BeginInvokeOnMainThread(new Action(() => { 
		    	updateTextBoxnadLabelHiddenProperty(true,true,true,false,false,false,false);
	            }));
                    break;
                default:
		    this.BeginInvokeOnMainThread(new Action(() => { 
		    	updateTextBoxnadLabelHiddenProperty(true,true,true,true,true,true,true);
	            }));
                    break;
                    
            }
        }
        void updateErrorTextbox(String text)
        {
            this.errorTextbox.InvokeOnMainThread(new Action(() => {
                this.errorTextbox.Text = text;
            }));
        }

        partial void GenerateRN_TouchUpInside(UIButton sender)
        {
            //clear error text box in attempt to generate new random number.
           updateErrorTextbox(String.Empty);

            //prepare for switch statement
            nint caseSwitch = stepper1.SelectedSegment;

            double lambda, gamma;
            double mu, sigmaSquared;

            //switch statement
            switch (caseSwitch)
            {
                case 0:
                    RN.InvokeOnMainThread(new Action(() => {
                    	this.RN.Text = UniformDoublePRNG.NextDouble().ToString();
                    }));
                    break;
                case 1:
                    
                    if (!(this.normalMeanTextbox.Text == "") && Helper.IsNumeric(this.normalMeanTextbox.Text))
                        mu = Convert.ToDouble(this.normalMeanTextbox.Text);
                    else
                    {
                        updateErrorTextbox("Mean Field not Complete");
                        break;
                    }
                    if (!(this.normalVarianceTextbox.Text == String.Empty))
                        sigmaSquared = Convert.ToDouble(this.normalVarianceTextbox.Text);
                    else
                    {
                        updateErrorTextbox("Variance Field not Complete");
                        break;
                    }
                    if (sigmaSquared <= 0.0)
                        updateErrorTextbox("Invalid Variance Value");
                    else
                        this.RN.InvokeOnMainThread(new Action(() => {
                        	this.RN.Text = Normal.getNormal(mu, sigmaSquared).ToString();
                        }));
                    break;
                case 2:
                    if(!(this.exponentialParameterTextbox.Text == String.Empty))
                        lambda = Convert.ToDouble(this.exponentialParameterTextbox.Text);
                    else
                    {
                         "Parameter Field not Complete";
                        break;
                    }
                    if (lambda <= 0)
                        updateErrorTextbox("Invalid Exponential Parameter");
                    else
                        this.RN.InvokeOnMainThread(new Action(() => {
                        	this.RN.Text = Exponential.getExponentialPRNG(lambda).ToString();
                        }));
                    break;
                case 3:
                    if (!(this.exponentialParameterLabel.Text == String.Empty) || !(this.normalVarianceTextbox.Text == String.Empty))
                    {
                        lambda = Convert.ToDouble(this.exponentialParameterTextbox.Text);
                        gamma = Convert.ToDouble(this.normalVarianceTextbox.Text);
                    }
                    else
                    {
                        updateErrorTextbox("Parameter Field not Complete");
                        break;
                    }
                    if (lambda <= 0)
                        updateErrorTextbox("Invalid Lambda");
                    else if (gamma <= 0)
                        updateErrorTextbox("Invalid Gamma");
                    else
                        this.RN.InvokeOnMainThread(new Action(() => {
                        	this.RN.Text = UniformDoublePRNG.PRNGUni.getWeibull(lambda, gamma).ToString();
                        }));
                    break;
                default:
                    this.RN.InvokeOnMainThread(new Action(() => {
                    	this.RN.Text = (0.0).ToString();
                    }));
                    break;

            }
        }


        protected ViewController(IntPtr handle) : base(handle)
        {
            // Note: this .ctor should not contain any initialization logic.
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            // Perform any additional setup after loading the view, typically from a nib.

            this.selectStepper1(this.stepper1);
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}
