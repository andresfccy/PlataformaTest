angular.module('plataformaTest.test')
    .factory('TestService', ['$resource', 'CommonsConstants', 
        function ($resource, CommonsConstants) {
            var baseUrl = CommonsConstants.factory.API_BASE_URL() + CommonsConstants.factory.API_MATERIALS_PATH;
            var url = '';
            var paramDefaults = {};
            var actions = {
                getMaterials: { method: 'GET', url: baseUrl, headers: {}, isArray: true },
                update: { method: 'PUT', url: baseUrl, headers: {} },
                save: { method: 'POST', url: baseUrl, headers: {} },
                getMaterialsByStudy: { method: 'GET', url: baseUrl + "/Estudio", headers: {}, isArray: true },
            };
            return $resource(url, paramDefaults, actions);
        }
    ]);