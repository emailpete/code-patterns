#region New BSD License

// Copyright (c) 2012, John Batte
// All rights reserved.
// 
// Redistribution and use in source and binary forms, with or without modification, are permitted
// provided that the following conditions are met:
// 
// Redistributions of source code must retain the above copyright notice, this list of conditions
// and the following disclaimer.
// 
// Redistributions in binary form must reproduce the above copyright notice, this list of conditions
// and the following disclaimer in the documentation and/or other materials provided with the distribution.
// 
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND ANY EXPRESS OR IMPLIED
// WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A
// PARTICULAR PURPOSE ARE DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR
// ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT NOT LIMITED
// TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION)
// HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING
// NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE
// POSSIBILITY OF SUCH DAMAGE.

#endregion

using Autofac;

using FluentAssertions;

using Patterns.Runtime;
using Patterns.Specifications.Framework;

using TechTalk.SpecFlow;

namespace Patterns.Specifications.Steps.Autofac.Runtime
{
	[Binding]
	public class DefaultDateTimeInfoSteps
	{
		private static readonly string _dateTimeInfoKey = ScenarioContext.Current.NewKey();

		public static IDateTimeInfo DateTimeInfo
		{
			get { return ScenarioContext.Current.Pull<IDateTimeInfo>(_dateTimeInfoKey); }
			set { ScenarioContext.Current[_dateTimeInfoKey] = value; }
		}

		[When("I try to resolve the IDateTimeInfo interface")]
		public void ResolveDateTimeInfo()
		{
			DateTimeInfo = ContainerSteps.Container.Resolve<IDateTimeInfo>();
		}

		[Then("the resolved object should be an instance of DefaultDateTimeInfo")]
		public void VerifyType()
		{
			DateTimeInfo.Should().NotBeNull().And.BeOfType<DefaultDateTimeInfo>();
		}
	}
}