using Newtonsoft.Json;
using RestSharp;
using SpecFlowTest.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using TechTalk.SpecFlow;
using UserDetails.Model;
using Xunit;

namespace SpecFlowTest
{
    [Binding]
    public sealed class UserDetailsDefination
    {
        // For additional details on SpecFlow step definitions see https://go.specflow.org/doc-stepdef

        private readonly ScenarioContext _scenarioContext;
        private User _user;
        private HttpResponseMessage _getResponse;

        public UserDetailsDefination(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        [Given(@"I want run Userdetail api and id is (.*)")]
        public void GivenIWantRunUserdetailApiAndIdIs(int id)
        {
            _user = new User();
            _user.Id = id;
            
        }

        [When(@"I execute userdetail api")]
        public  void WhenIExecuteUserdetailApi()
        {
            _getResponse =RestServiceCall.GetUserDetailById(_user.Id);
        }

        [Then(@"I should get returnCode as (.*)")]
        public void ThenIShouldGetReturnCodeAs(int statusCode)
        {
            int statuscode = (int)_getResponse.StatusCode;
            Assert.Equal(statusCode.ToString(), statuscode.ToString());
        }

        [Then(@"verify userdetail data with given inputs name is (.*) and email is (.*) and country is (.*)")]
        public void ThenVerifyUserdetailDataWithGivenInputsNameIsAndEmailIsAndCountryIs(string name, string email, string country)
        {
            var response = JsonConvert.DeserializeObject<User>(_getResponse.Content.ReadAsStringAsync().Result);
            Assert.Equal(name, response?.Name??string.Empty);
            Assert.Equal(email, response?.Email??string.Empty);
            Assert.Equal(country, response?.Country??string.Empty);
        }

        [Given(@"name is (.*)")]
        public void GivenName(string name)
        {
            _user.Name = name;
        }

        [Given(@"email is (.*)")]
        public void GivenEmail(string email)
        {
            _user.Email = email;
        }

        [Given(@"country is (.*)")]
        public void GivenCountry(string country)
        {
            _user.Country = country;
        }

        [When(@"I execute add userdetail api")]
        public void WhenIExecuteAddUserdetailApi()
        {
            _getResponse = RestServiceCall.AddUser(_user);
        }

        [Given(@"update name is (.*)")]
        public void GivenUpdateName(string name)
        {
            _user.Name = name;  
        }

        [Given(@"update email is (.*)")]
        public void GivenUpdateEmail(string email)
        {
            _user.Email = email;
        }

        [Given(@"update country (.*)")]
        public void GivenUpdateCountry(string country)
        {
            _user.Country = country;
        }

        [When(@"I execute update userdetail api")]
        public void WhenIExecuteUpdateUserdetailApi()
        {
            _getResponse = RestServiceCall.UpdateUser(_user.Id);
        }

    }
}
