﻿// Copyright 2019 Google LLC
//
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
//
//     https://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.

// Generated code. DO NOT EDIT!

namespace Testing.Basic.V1.Snippets
{
    // [START basic_v1_generated_Basic_AMethod_sync]
    using Testing.Basic.V1;

    public sealed partial class GeneratedBasicClientSnippets
    {
        /// <summary>Snippet for AMethod</summary>
        /// <remarks>
        /// This snippet has been automatically generated for illustrative purposes only.
        /// It may require modifications to work in your environment.
        /// </remarks>
        public void AMethodRequestObject()
        {
            // Create client
            BasicClient basicClient = BasicClient.Create();
            // Initialize request argument(s)
            Request request = new Request { };
            // Make the request
            Response response = basicClient.AMethod(request);
        }
    }
    // [END basic_v1_generated_Basic_AMethod_sync]
}
