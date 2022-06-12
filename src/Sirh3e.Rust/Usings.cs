global using System;
global using System.Collections;
global using System.Collections.Generic;
global using System.Diagnostics.Contracts;
global using System.Threading.Tasks;
#if !NET2_0_OR_GREATER
global using System.Reflection;
#endif
global using System.Runtime.CompilerServices;
global using Sirh3e.Rust.Attributes;
global using Sirh3e.Rust.Internals.Helpers;
global using Sirh3e.Rust.Option;
global using Sirh3e.Rust.Panic;
global using Sirh3e.Rust.Result;
global using static Sirh3e.Rust.Option.Extension;
global using static Sirh3e.Rust.Result.Extension;