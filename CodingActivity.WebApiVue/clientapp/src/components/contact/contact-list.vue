<template>
    <div class="container-fluid">
        <div class="row" style="margin-bottom: 10px;">
            <a href="#" @click.prevent="editContact(0)">
                <i class="fas fa-user-plus fa-5x"></i>
            </a>
        </div>
        <div class="row">
            <div class="col">
                <table class="table table-hover">
                    <thead class="thead-dark">
                        <tr>
                            <th scope="col">First Name
                                <a href="#" @click.prevent="applySort('FirstName')" class="float-right">
                                    <i class="fas"
                                        :class="[{'fa-arrows-alt-v':columnSort!='FirstName'},{'fa-arrow-up':columnSort=='FirstName'&& sortType=='ASC' },{'fa-arrow-down':columnSort=='FirstName' && sortType=='DESC'}]"></i>
                                </a>
                            </th>
                            <th scope="col">Last Name
                                <a href="#" @click.prevent="applySort('LastName')" class="float-right">
                                    <i class="fas"
                                        :class="[{'fa-arrows-alt-v':columnSort!='LastName'},{'fa-arrow-up':columnSort=='LastName'&& sortType=='ASC' },{'fa-arrow-down':columnSort=='LastName' && sortType=='DESC'}]"></i>
                                </a>
                            </th>
                            <th scope="col">City
                                <a href="#" @click.prevent="applySort('Address.City')" class="float-right">
                                    <i class="fas"
                                        :class="[{'fa-arrows-alt-v':columnSort!='Address.City'},{'fa-arrow-up':columnSort=='Address.City'&& sortType=='ASC' },{'fa-arrow-down':columnSort=='Address.City' && sortType=='DESC'}]"></i>
                                </a>
                            </th>
                            <th scope="col">State
                                <a href="#" @click.prevent="applySort('Address.State')" class="float-right">
                                    <i class="fas"
                                        :class="[{'fa-arrows-alt-v':columnSort!='Address.State'},{'fa-arrow-up':columnSort=='Address.State'&& sortType=='ASC' },{'fa-arrow-down':columnSort=='Address.State' && sortType=='DESC'}]"></i>
                                </a>
                            </th>
                            <th scope="col">Phone Number
                                <a href="#" @click.prevent="applySort('PhoneNumber')" class="float-right">
                                    <i class="fas"
                                        :class="[{'fa-arrows-alt-v':columnSort!='PhoneNumber'},{'fa-arrow-up':columnSort=='PhoneNumber'&& sortType=='ASC' },{'fa-arrow-down':columnSort=='PhoneNumber' && sortType=='DESC'}]"></i>
                                </a>
                            </th>
                            <th scope="col">Actions </th>
                        </tr>
                    </thead>
                    <tbody v-if="contacts!=undefined">
                        <tr v-for="c in contacts" :key="c.id">
                            <td>{{c.firstName}}</td>
                            <td>{{c.lastName}}</td>
                            <td>{{c.address.city}}</td>
                            <td>{{c.address.state}}</td>
                            <td>{{c.phoneNumber}}</td>
                            <td>
                                <a href="#" @click.prevent="editContact(c.id)">
                                    <i class="far fa-edit"></i>
                                </a>
                                /
                                <a href="#" @click.prevent="showRemove(true,c.id)">
                                    <i class="far fa-trash-alt"></i>
                                </a>
                            </td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div class="col">
                <router-view></router-view>
            </div>
        </div>
        <div class="modal" :class="{show:showModalRemove}" tabindex="-1" role="dialog" aria-modal="true">
            <div class="modal-dialog" role="document">
                <div class="modal-content">
                    <div class="modal-header">
                        <h5 class="modal-title">Remove Contact</h5>
                        <button type="button" class="close" data-dismiss="modal" aria-label="Close">
                            <span aria-hidden="true">&times;</span>
                        </button>
                    </div>
                    <div class="modal-body">
                        <p>Are you sure you want to remove this concat?</p>
                    </div>
                    <div class="modal-footer">
                        <button type="button" class="btn btn-secondary" data-dismiss="modal"
                            @click.prevent="showRemove(false,0)">Close</button>
                        <button type="button" class="btn btn-danger" @click.prevent="removeContact()">Remove</button>
                    </div>
                </div>
            </div>
        </div>
    </div>
</template>

<script>
    import { mapActions } from 'vuex';
    import contactService from './../../services/contact-service.js';

    export default {
        name: 'contact-list',
        data() {
            return {
                showModalRemove: false,
                concatIdToDelete: 0,
                sortType: 'ASC',
                columnSort: ''
            }
        },
        created() {
            this.getData();
        },
        computed: {
            contacts() {
                return this.$store.getters.contacts;
            },
            sort() {
                return this.$store.getters.sort;
            }
        },
        methods: {
            ...mapActions(['updateContacts', 'updateSort']),
            getData() {
                contactService.getContacts(this.sort)
                    .then(r => r.json())
                    .then(d => {
                        this.updateContacts(d);
                    });
            },
            showRemove(value, contactId) {
                this.showModalRemove = value;
                this.concatIdToDelete = contactId;
            },
            removeContact() {
                let contactId = this.concatIdToDelete;
                let routeContactId = this.$route.params.id;
                contactService.removeContact(contactId)
                    .then(() => {
                        this.showRemove(false, 0);
                        this.getData();

                        if (this.$route.name != 'contacts' && routeContactId == contactId) {
                            this.$router.push({ name: 'contacts' })
                        }
                    });
            },
            editContact(contactId) {
                if (contactId != this.$route.params.id) {
                    this.$router.push({ name: 'contact', params: { id: contactId } });
                }
            },
            applySort(column) {
                if (column !== this.columnSort) {
                    this.sortType = 'ASC'
                } else {
                    if (this.sortType == 'DESC') {
                        this.sortType = 'ASC'
                    } else {
                        this.sortType = 'DESC'
                    }
                }

                this.columnSort = column;
                this.updateSort(`${this.columnSort} ${this.sortType}`);
                this.getData();
            }
        },
    }
</script>

<style scoped>
    a {
        color: #212529;
    }

    .show {
        display: block;
    }

    th>a {
        color: #fff;
    }
</style>