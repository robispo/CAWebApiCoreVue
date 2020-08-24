import home from './components/home.vue';
import contactList from './components/contact/contact-list.vue';
import contact from './components/contact/contact.vue';

export const routes = [
  { path: '/', redirect: { name: 'home' } },
  { path: '/home', component: home, name: 'home' },
  {
    path: '/contacts',
    name: 'contacts',
    component: contactList,
    children: [{ path: ':id', component: contact, name: 'contact' }],
  },
  { path: '*', redirect: { name: 'home' } },
];
