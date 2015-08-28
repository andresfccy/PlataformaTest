var commonsModule = angular.module('plataformaTest.commons')
    .factory('CommonsConstants', [
        function () {
            var factory = {
                // Define here api services URLs.
                API_TEST_PATH: '/api/Test'
            };

            return {
                factory: factory
            };
        }
    ]
);