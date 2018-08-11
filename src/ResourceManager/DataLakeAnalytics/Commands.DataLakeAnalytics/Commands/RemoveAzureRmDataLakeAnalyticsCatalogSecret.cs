﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.DataLakeAnalytics.Models;
using Microsoft.Azure.Commands.DataLakeAnalytics.Properties;
using System;
using System.Management.Automation;

namespace Microsoft.Azure.Commands.DataLakeAnalytics
{
    [Cmdlet("Remove", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "DataLakeAnalyticsCatalogSecret", SupportsShouldProcess = true), OutputType(typeof(bool))]
    [Alias("Remove-AdlCatalogSecret")]
    [Obsolete("Catalog secrets are being deprecated in a future release. Please use Remove-AzureRmDataLakeAnalyticsCatalogCredential directly instead.")]
    public class RemoveAzureDataLakeAnalyticsSecret : DataLakeAnalyticsCmdletBase
    {
        [Parameter(ValueFromPipelineByPropertyName = true, Position = 0, Mandatory = true,
            HelpMessage = "The account name that contains the catalog to remove the secret(s) from.")]
        [ValidateNotNullOrEmpty]
        [Alias("AccountName")]
        public string Account { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 1, Mandatory = true,
            HelpMessage = "The name of the database to remove the secret(s) from.")]
        [ValidateNotNullOrEmpty]
        public string DatabaseName { get; set; }

        [Parameter(ValueFromPipelineByPropertyName = true, Position = 2, Mandatory = false,
            HelpMessage =
                "Name of secret to be removed. If none specified, will remove all secrets in the specified database")]
        [ValidateNotNullOrEmpty]
        public string Name { get; set; }

        [Parameter(Position = 3, Mandatory = false, HelpMessage = "Do not ask for confirmation.")]
        public SwitchParameter Force { get; set; }

        [Parameter(Position = 4, Mandatory = false)]
        public SwitchParameter PassThru { get; set; }

        public override void ExecuteCmdlet()
        {
            if (string.IsNullOrEmpty(Name))
            {
                ConfirmAction(
                Force.IsPresent,
                string.Format(Resources.RemovingDataLakeAnalyticsCatalogSecrets, DatabaseName),
                string.Format(Resources.RemoveDataLakeAnalyticsCatalogSecrets, DatabaseName),
                DatabaseName,
                    () =>
                    {
                        DataLakeAnalyticsClient.DeleteSecret(Account, DatabaseName, Name);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }
            else
            {
                ConfirmAction(
                    Force.IsPresent,
                    string.Format(Resources.RemovingDataLakeAnalyticsCatalogSecret, Name),
                    string.Format(Resources.RemoveDataLakeAnalyticsCatalogSecret, Name),
                    Name,
                    () =>
                    {
                        DataLakeAnalyticsClient.DeleteSecret(Account, DatabaseName, Name);
                        if (PassThru)
                        {
                            WriteObject(true);
                        }
                    });
            }
        }
    }
}
