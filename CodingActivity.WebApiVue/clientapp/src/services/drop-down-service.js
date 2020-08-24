import Vue from 'vue';
import VueResource from 'vue-resource';

Vue.use(VueResource);

const baseUrl = 'http://localhost:50598/api/contact';

const getDropDowns = (dropdowns) => {
  return Vue.http.get(`${baseUrl}/dropdown/${dropdowns}`);
};


export default {
  getDropDowns
};
