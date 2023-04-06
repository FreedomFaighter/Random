// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;

namespace Random
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField errorTextbox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel exponentialParameterLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField exponentialParameterTextbox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton generateRN { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel normalMeanLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField normalMeanTextbox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel normalVarianceLabel { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField normalVarianceTextbox { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField RN { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl stepper1 { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel weibullLabel { get; set; }

        [Action ("GenerateRN_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void GenerateRN_TouchUpInside (UIKit.UIButton sender);

        [Action ("RNValueChanged:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void RNValueChanged (UIKit.UITextField sender);

        [Action ("selectStepper1:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void selectStepper1 (UIKit.UISegmentedControl sender);

        void ReleaseDesignerOutlets ()
        {
            if (errorTextbox != null) {
                errorTextbox.Dispose ();
                errorTextbox = null;
            }

            if (exponentialParameterLabel != null) {
                exponentialParameterLabel.Dispose ();
                exponentialParameterLabel = null;
            }

            if (exponentialParameterTextbox != null) {
                exponentialParameterTextbox.Dispose ();
                exponentialParameterTextbox = null;
            }

            if (generateRN != null) {
                generateRN.Dispose ();
                generateRN = null;
            }

            if (normalMeanLabel != null) {
                normalMeanLabel.Dispose ();
                normalMeanLabel = null;
            }

            if (normalMeanTextbox != null) {
                normalMeanTextbox.Dispose ();
                normalMeanTextbox = null;
            }

            if (normalVarianceLabel != null) {
                normalVarianceLabel.Dispose ();
                normalVarianceLabel = null;
            }

            if (normalVarianceTextbox != null) {
                normalVarianceTextbox.Dispose ();
                normalVarianceTextbox = null;
            }

            if (RN != null) {
                RN.Dispose ();
                RN = null;
            }

            if (stepper1 != null) {
                stepper1.Dispose ();
                stepper1 = null;
            }

            if (weibullLabel != null) {
                weibullLabel.Dispose ();
                weibullLabel = null;
            }
        }
    }
}