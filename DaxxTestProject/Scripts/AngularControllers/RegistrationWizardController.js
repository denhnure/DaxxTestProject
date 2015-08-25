angular.module('RegistrationWizard', [])
    .controller('RegistrationWizardController', [
            '$scope', 'RegistrationService', function($scope, RegistrationService) {
                $scope.currentStep = 1;
                $scope.FinalStep = 2;
                $scope.userRegistrationResult = null;

                $scope.Country = null;
                $scope.State = null;
                $scope.CountryList = null;
                $scope.StateList = null;
                $scope.StateTextToShow = null;

                RegistrationService.GetCountry().then(function(d) {
                    $scope.CountryList = d.data;
                });

                $scope.GetState = function() {
                    $scope.State = null;
                    $scope.StateList = null;

                    if ($scope.Country == null) {
                        $scope.StateTextToShow = null;
                    } else {
                        $scope.StateTextToShow = "Please Wait...";
                    }

                    RegistrationService.GetState($scope.Country.Id).then(function(d) {
                        $scope.StateList = d.data;
                        $scope.StateTextToShow = "Select State";
                    });
                }

                $scope.submit = function(formValid) {
                    if (formValid) {
                        if ($scope.currentStep == $scope.FinalStep) {

                            RegistrationService.AddUser($scope.Login, $scope.Password, $scope.AgreeToWorkForFood, $scope.Country.Id, $scope.State.Id).then(function(d) {
                                $scope.userRegistrationResult = 'New user has been added!';
                            }, function() {
                                $scope.userRegistrationResult = 'Failure';
                            });

                        }

                        if ($scope.Password === $scope.ConfirmPassword) {
                            $scope.currentStep++;
                        }
                    }
                };
            }
        ]
    )
    .factory('RegistrationService', function($http) {
        var fac = {};

        fac.GetCountry = function() {
            return $http.get('/api/Countries');
        }

        fac.GetState = function(countryId) {
            return $http.get('/api/States/' + countryId);
        }

        fac.AddUser = function(login, password, agreeToWorkForFood, countryId, stateId) {
            return $http.post('/api/Users', { Login: login, Password: password, AgreeToWorkForFood: agreeToWorkForFood, CountryId: countryId, StateId: stateId });
        }

        return fac;
    });

