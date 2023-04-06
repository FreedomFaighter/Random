using System;
using UIKit;

namespace Random
{
    public partial class ViewController : UIViewController
    {
        partial void RNValueChanged(UITextField sender)
        {
            this.RN.Copy();
            this.errorTextbox.Text = "Random Number Copied.";
        }

        partial void selectStepper1(UISegmentedControl sender)
        {
            nint caseSwitch = this.stepper1.SelectedSegment;

            switch (caseSwitch)
            {
                case 0:
                    this.normalMeanLabel.Hidden = true;
                    this.normalVarianceLabel.Hidden = true;
                    this.normalMeanTextbox.Hidden = true;
                    this.normalVarianceTextbox.Hidden = true;
                    this.exponentialParameterLabel.Hidden = true;
                    this.exponentialParameterTextbox.Hidden = true;
                    this.weibullLabel.Hidden = true;
                    break;
                case 1:
                    this.normalMeanLabel.Hidden = false;
                    this.normalVarianceLabel.Hidden = false;
                    this.normalMeanTextbox.Hidden = false;
                    this.normalVarianceTextbox.Hidden = false;
                    this.exponentialParameterLabel.Hidden = true;
                    this.exponentialParameterTextbox.Hidden = true;
                    this.weibullLabel.Hidden = true;
                    break;
                case 2:
					this.normalMeanLabel.Hidden = true;
					this.normalVarianceLabel.Hidden = true;
					this.normalMeanTextbox.Hidden = true;
					this.normalVarianceTextbox.Hidden = true;
                    this.exponentialParameterLabel.Hidden = false;
                    this.exponentialParameterTextbox.Hidden = false;
                    this.weibullLabel.Hidden = true;
                    break;
                case 3:
					this.normalMeanLabel.Hidden = true;
					this.normalVarianceLabel.Hidden = true;
					this.normalMeanTextbox.Hidden = true;
                    this.normalVarianceTextbox.Hidden = false;
                    this.exponentialParameterLabel.Hidden = false;
                    this.exponentialParameterTextbox.Hidden = false;
                    this.weibullLabel.Hidden = false;
                    break;
                default:
					this.normalMeanLabel.Hidden = true;
					this.normalVarianceLabel.Hidden = true;
					this.normalMeanTextbox.Hidden = true;
					this.normalVarianceTextbox.Hidden = true;
                    this.exponentialParameterLabel.Hidden = true;
                    this.exponentialParameterTextbox.Hidden = true;
                    this.weibullLabel.Hidden = true;
                    break;
                    
            }
        }

        partial void GenerateRN_TouchUpInside(UIButton sender)
        {
            //clear error text box in attempt to generate new random number.
            this.errorTextbox.Text = "";
            //prepare for switch statement
            nint caseSwitch = stepper1.SelectedSegment;

            double lambda, gamma;
            double mu, sigmaSquared;

            //switch statement
            switch (caseSwitch)
            {
                case 0:
                    this.RN.Text = UniformDoublePRNG.NextDouble().ToString();
                    break;
                case 1:
                    
                    if (!(this.normalMeanTextbox.Text == "") && Helper.IsNumeric(this.normalMeanTextbox.Text))
                        mu = Convert.ToDouble(this.normalMeanTextbox.Text);
                    else
                    {
                        this.errorTextbox.Text = "Mean Field not Complete";
                        break;
                    }
                    if (!(this.normalVarianceTextbox.Text == ""))
                        sigmaSquared = Convert.ToDouble(this.normalVarianceTextbox.Text);
                    else
                    {
                        this.errorTextbox.Text = "Variance Field not Complete";
                        break;
                    }
                    if (sigmaSquared <= 0.0)
                        this.errorTextbox.Text = "Invalid Variance Value.";
                    else
                        this.RN.Text = Normal.getNormal(mu, sigmaSquared).ToString();
                    break;
                case 2:
                    if(!(this.exponentialParameterTextbox.Text==""))
                        lambda = Convert.ToDouble(this.exponentialParameterTextbox.Text);
                    else
                    {
                        this.errorTextbox.Text = "Parameter Field not Complete";
                        break;
                    }
                    if (lambda <= 0)
                        this.errorTextbox.Text = "Invalid Exponential Parameter.";
                    else
                        this.RN.Text = Exponential.getExponentialPRNG(lambda).ToString();
                    break;
                case 3:
                    if (!(this.exponentialParameterLabel.Text == "") || !(this.normalVarianceTextbox.Text == ""))
                    {
                        lambda = Convert.ToDouble(this.exponentialParameterTextbox.Text);
                        gamma = Convert.ToDouble(this.normalVarianceTextbox.Text);
                    }
                    else
                    {
                        this.errorTextbox.Text = "Parameter Field not Complete.";
                        break;
                    }
                    if (lambda <= 0)
                        this.errorTextbox.Text = "Invalid Lambda.";
                    else if (gamma <= 0)
                        this.errorTextbox.Text = "Invalid Gamma.";
                    else
                        this.RN.Text = UniformDoublePRNG.PRNGUni.getWeibull(lambda, gamma).ToString();
                    break;
                default:
                    this.RN.Text = (0.0).ToString();
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