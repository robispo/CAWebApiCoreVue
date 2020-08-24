import Vue from 'vue';
import VueResource from 'vue-resource';

Vue.use(VueResource);

const baseUrl = 'http://localhost:50598/api/contact';

const getContacts = (sort) => {
  return Vue.http.get(`${baseUrl}/getall`, { params: { sort } });
};

const getContact = (id) => {
  return Vue.http.get(`${baseUrl}/${id}`);
};

const removeContact = (id) => {
  return Vue.http.delete(`${baseUrl}/${id}`);
};

const addContact = (contact) => {
  return Vue.http.post(`${baseUrl}`, contact);
};

const updateContact = (contact) => {
  return Vue.http.put(`${baseUrl}`, contact);
};

export default {
  getContact,
  getContacts,
  removeContact,
  addContact,
  updateContact,
};
