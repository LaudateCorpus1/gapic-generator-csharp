﻿// Copyright 2018 Google Inc. All Rights Reserved.
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

using Google.Api.Generator.ProtoUtils;
using Google.Api.Generator.Utils;
using Google.Protobuf.Reflection;
using System.Collections.Generic;
using System.Linq;

namespace Google.Api.Generator.Generation
{
    /// <summary>
    /// Details of a proto-defined service.
    /// </summary>
    internal class ServiceDetails
    {
        public ServiceDetails(ProtoCatalog catalog, string ns, ServiceDescriptor desc)
        {
            Catalog = catalog;
            Namespace = ns;
            ProtoTyp = Typ.Manual(ns, desc.Name);
            GrpcClientTyp = Typ.Nested(ProtoTyp, $"{desc.Name}Client");
            SettingsTyp = Typ.Manual(ns, $"{desc.Name}Settings");
            ClientAbstractTyp = Typ.Manual(ns, $"{desc.Name}Client");
            ClientImplTyp = Typ.Manual(ns, $"{desc.Name}ClientImpl");
            desc.CustomOptions.TryGetString(ProtoConsts.ServiceOption.DefaultHost, out var defaultHost);
            DefaultHost = defaultHost;
            DefaultPort = 443; // Hardcoded; this is not specifiable by proto annotation.
            Methods = desc.Methods.Select(x => MethodDetails.Create(this, x)).ToList();
        }

        public ProtoCatalog Catalog { get; }
        public string Namespace { get; }

        /// <summary>
        /// The outer typ of the protoc-generated C# code.
        /// </summary>
        public Typ ProtoTyp { get; }

        /// <summary>
        /// The typ of the grpc-protoc-generated C# gRPC client code.
        /// </summary>
        public Typ GrpcClientTyp { get; }

        /// <summary>
        /// The typ of the GAPIC settings class for this service.
        /// </summary>
        public Typ SettingsTyp { get; }

        /// <summary>
        /// The typ of the GAPIC abstract client for this service.
        /// </summary>
        public Typ ClientAbstractTyp { get; }

        /// <summary>
        /// The typ of the GAPIC client implementation for this service.
        /// </summary>
        public Typ ClientImplTyp { get; }

        /// <summary>
        /// The default hostname for this service.
        /// </summary>
        public string DefaultHost { get; }

        /// <summary>
        /// The default port for this service.
        /// </summary>
        public int DefaultPort { get; }

        /// <summary>
        /// All RPC methods within this service.
        /// </summary>
        public IEnumerable<MethodDetails> Methods { get; }
    }
}
