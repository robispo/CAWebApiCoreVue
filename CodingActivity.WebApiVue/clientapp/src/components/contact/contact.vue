<template>
    <div>
        <form>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="first-name">First Name</label>
                    <input type="text" class="form-control" :class="{'is-invalid':errors.has('first-name')}"
                        id="first-name" name="first-name" maxlength="20" required placeholder="First Name"
                        v-model.trim="contact.firstName" v-validate="'required|max:20'">

                </div>
                <div class="form-group col-md-6">
                    <label for="last-name">Last Name</label>
                    <input type="text" class="form-control" id="last-name" name="last-name" maxlength="20"
                        placeholder="Last Name" :class="{'is-invalid':errors.has('last-name')}"
                        v-model.trim="contact.lastName" v-validate="'required|max:20'">
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="email">Email</label>
                    <input type="email" class="form-control" id="email" name="email" placeholder="Email"
                        :class="{'is-invalid':errors.has('email')}" v-model.trim="contact.email" v-validate="'email'">
                </div>
                <div class="form-group col-md-6">
                    <label for="phone-number">Phone Number</label>
                    <input type="tel" class="form-control" id="phone-number" name="phone-number"
                        placeholder="Phone Number" :class="{'is-invalid':errors.has('phone-number')}"
                        v-model.trim="contact.phoneNumber" v-validate="'numeric'">
                </div>
            </div>
            <div class="form-group">
                <label for="street">Street</label>
                <input type="text" class="form-control" id="street" name="street" maxlength="100"
                    placeholder="1234 Main St" :class="{'is-invalid':errors.has('street')}"
                    v-model.trim="contact.address.street" v-validate="'max:100'">
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="city">City</label>
                    <input type="text" class="form-control" id="city" name="city" maxlength="50" placeholder="New York"
                        :class="{'is-invalid':errors.has('city')}" v-model.trim="contact.address.city"
                        v-validate="'max:50'">
                </div>
                <div class="form-group col-md-4">
                    <label for="state">State</label>
                    <select id="state" class="form-control" v-model="contact.address.stateCode">
                        <option selected value="">Choose...</option>
                        <option v-for="state in states" :key="state.code" :value="state.code">{{state.stateName}}
                        </option>
                    </select>
                </div>
                <div class="form-group col-md-2">
                    <label for="zip">Zip</label>
                    <input type="number" class="form-control" id="zip" name="zip" v-model.number="contact.address.zip"
                        v-validate="'numeric'" :class="{'is-invalid':errors.has('zip')}">
                </div>
            </div>
            <div class="form-row">
                <div class="form-group col-md-6">
                    <label for="contact-frequency">Contact Frequency</label>
                    <select id="contact-frequency" class="form-control" v-model="contact.contactFrequency">
                        <option selected value="0">Choose...</option>
                        <option v-for="contactFrequency in contactFrequencies" :key="contactFrequency.id"
                            :value="contactFrequency.id">{{contactFrequency.frequency}}</option>
                    </select>
                </div>
                <div class="form-group col-md-6">
                    <label for="preferred-contact-method">Preferred Contact Method</label>
                    <select id="preferred-contact-method" class="form-control" v-model="contact.preferredContactMethod">
                        <option selected value="0">Choose...</option>
                        <option v-for="preferredContactMethod in preferredContactMethods"
                            :key="preferredContactMethod.id" :value="preferredContactMethod.id">
                            {{preferredContactMethod.method}}</option>
                    </select>
                </div>
            </div>
            <div class="form-row">
                <button type="submit" class="btn btn-primary" @click.prevent="save()">Save</button>
                <button type="submit" class="btn btn-secondary" @click.prevent="backToContacts()">Dismiss</button>
            </div>
        </form>
    </div>
</template>

<script>
    import { mapActions } from 'vuex';
    import contactService from './../../services/contact-service.js';
    import dropDownService from './../../services/drop-down-service.js';

    export default {
        data() {
            return {
                contactId: 0,
                isNewContact: true,
                contactNoFound: false,
                contact: {
                    firstName: '',
                    lastName: '',
                    email: '',
                    phoneNumber: '',
                    address: {
                        street: '',
                        stateCode: '',
                        city: '',
                        zip: ''
                    },
                    contactFrequency: 0,
                    preferredContactMethod: 0
                },
                states: [],
                contactFrequencies: [],
                preferredContactMethods: []
            }
        },
        computed: {
            sort() {
                return this.$store.getters.sort;
            }
        },
        created() {
            dropDownService.getDropDowns('state,contactfrequency,preferredcontactmethod')
                .then(r => r.json())
                .then(d => {
                    d.forEach(dd => {
                        switch (dd.name) {
                            case "state":
                                this.states = dd.data;
                                break;
                            case "contactfrequency":
                                this.contactFrequencies = dd.data;
                                break;
                            case "preferredcontactmethod":
                                this.preferredContactMethods = dd.data;
                                break;
                        }
                    });
                });

            if (this.$route.params.id > 0) {
                this.contactId = this.$route.params.id;
                this.getContact();
            }

            this.isNewContact = this.$route.params.id <= 0;
        },
        watch: {
            $route(to) {
                this.contactId = to.params.id;
                this.isNewContact = this.contactId <= 0;

                if (this.contactId == 0) {
                    this.emptyContact();
                    return;
                }

                this.getContact();
            }
        },
        methods: {
            ...mapActions(['updateContacts']),
            emptyContact() {
                this.contact = {
                    firstName: '',
                    lastName: '',
                    email: '',
                    phoneNumber: '',
                    address: {
                        street: '',
                        stateCode: '',
                        city: '',
                        zip: ''
                    },
                    contactFrequency: 0,
                    preferredContactMethod: 0
                };
            },
            getContact() {
                contactService.getContact(this.contactId)
                    .then(r => {
                        if (r.status == 204) {
                            this.emptyContact();
                            this.contactNoFound = true;
                        } else {
                            r.json().then(d => this.contact = d);
                        }
                    });
            },
            save() {
                this.$validator
                    .validate()
                    .then(valid => {
                        if (valid) {
                            this.contact.address.zip = this.contact.address.zip + '';
                            this.contact.id = this.contactId + '';

                            let action = this.isNewContact
                                ? contactService.addContact(this.contact)
                                : contactService.updateContact(this.contact);

                            action
                                .then(r => r.json())
                                .then(d => {
                                    this.contact = d;

                                    if (this.isNewContact) {
                                        this.$router.push({ name: 'contact', params: { id: this.contact.id } });
                                    }

                                    contactService.getContacts(this.sort)
                                        .then(r => r.json())
                                        .then(d => {
                                            this.updateContacts(d);
                                        });
                                });
                        }
                    });
            },
            backToContacts() {
                this.$router.push({ name: 'contacts' });
            }
        }
    }
</script>

<style scoped>
    .btn-secondary {
        margin-left: 5px;
    }
</style>