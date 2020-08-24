import Vue from 'vue';
import VueRouter from 'vue-router';
import VueResource from 'vue-resource';
import VeeValidate from 'vee-validate';

import App from './App.vue';
import { routes } from './routes.js';
import { store } from './store/store.js';

import 'bootstrap';
import 'bootstrap/dist/css/bootstrap.min.css';

Vue.use(VueRouter);
Vue.use(VueResource);
Vue.use(VeeValidate);

const router = new VueRouter({
  mode: 'history',
  routes,
});

Vue.config.productionTip = false;

new Vue({
  render: (h) => h(App),
  router,
  store
}).$mount('#app');
