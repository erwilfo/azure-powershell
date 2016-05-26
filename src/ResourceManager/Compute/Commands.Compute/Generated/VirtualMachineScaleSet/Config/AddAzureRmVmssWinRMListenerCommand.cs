// 
// Copyright (c) Microsoft and contributors.  All rights reserved.
// 
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//   http://www.apache.org/licenses/LICENSE-2.0
// 
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// 
// See the License for the specific language governing permissions and
// limitations under the License.
// 

// Warning: This code was generated by a tool.
// 
// Changes to this file may cause incorrect behavior and will be lost if the
// code is regenerated.

using Microsoft.Azure.Management.Compute.Models;
using System.Collections.Generic;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.Compute.Automation
{
    [Cmdlet("Add", "AzureRmVmssWinRMListener")]
    [OutputType(typeof(VirtualMachineScaleSet))]
    public class AddAzureRmVmssWinRMListenerCommand : Microsoft.Azure.Commands.ResourceManager.Common.AzureRMCmdlet
    {
        [Parameter(
            Mandatory = true,
            Position = 0,
            ValueFromPipeline = true,
            ValueFromPipelineByPropertyName = true)]
        public VirtualMachineScaleSet VirtualMachineScaleSet { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 1,
            ValueFromPipelineByPropertyName = true)]
        public ProtocolTypes? Protocol { get; set; }

        [Parameter(
            Mandatory = false,
            Position = 2,
            ValueFromPipelineByPropertyName = true)]
        public string CertificateUrl { get; set; }

        protected override void ProcessRecord()
        {
            // VirtualMachineProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetVMProfile();
            }

            // OsProfile
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile = new Microsoft.Azure.Management.Compute.Models.VirtualMachineScaleSetOSProfile();
            }

            // WindowsConfiguration
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration = new Microsoft.Azure.Management.Compute.Models.WindowsConfiguration();
            }

            // WinRM
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM = new Microsoft.Azure.Management.Compute.Models.WinRMConfiguration();
            }

            // Listeners
            if (this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM.Listeners == null)
            {
                this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM.Listeners = new List<Microsoft.Azure.Management.Compute.Models.WinRMListener>();
            }

            var vListeners = new Microsoft.Azure.Management.Compute.Models.WinRMListener();

            vListeners.Protocol = this.Protocol;
            vListeners.CertificateUrl = this.CertificateUrl;
            this.VirtualMachineScaleSet.VirtualMachineProfile.OsProfile.WindowsConfiguration.WinRM.Listeners.Add(vListeners);
            WriteObject(this.VirtualMachineScaleSet);
        }
    }
}

