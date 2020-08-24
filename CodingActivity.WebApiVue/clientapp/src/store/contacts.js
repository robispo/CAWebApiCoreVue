const state = {
  contacts: [],
  sort: '',
};
const getters = {
  contacts: (s) => s.contacts,
  sort: (s) => s.sort,
};
const mutations = {
  updateContact: (s, p) => (s.contacts = p),
  updateSort: (s, p) => (s.sort = p),
};
const actions = {
  updateContacts: (c, payload) => c.commit('updateContact', payload),
  updateSort: (c, payload) => c.commit('updateSort', payload),
};

export default {
  state,
  getters,
  mutations,
  actions,
};
