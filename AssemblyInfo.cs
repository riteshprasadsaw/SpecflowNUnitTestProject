using NUnit.Framework;
using System.Runtime.InteropServices;


[assembly: ComVisible(false)]

[assembly: Parallelizable(ParallelScope.Fixtures)]

[assembly: LevelOfParallelism(4)]

// The following GUID is for the ID of the typelib if this project is exposed to COM.

[assembly: Guid("6f714573-afb5-42f4-8b3b-dd2c22773a93")]
