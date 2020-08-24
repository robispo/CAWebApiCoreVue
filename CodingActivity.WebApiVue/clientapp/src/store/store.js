import Vue from 'vue';
import Vuex from 'vuex';
import contacts from './contacts.js';

Vue.use(Vuex);

export const store = new Vuex.Store({
  state: {
  },
  modules: {
    contacts
  },
});
