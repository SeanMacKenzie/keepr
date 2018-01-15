import axios from 'axios'
import vue from 'vue'
import vuex from 'vuex'
import router from '../router'

var production = !window.location.host.includes('localhost');
var baseUrl = production ? '//' : '//localhost:5000';

let api = axios.create({
    baseURL: baseUrl + '/api/',
    timeout: 2000,
    withCredentials: true
})

let auth = axios.create({
    baseURL: baseUrl,
    timeout: 2000,
    withCredentials: true
})
vue.use(vuex)

var store = new vuex.Store({
    state: {
        user: {},
        error: {},
        keeps: [],
        activekeep: {},
        vaults: [],
        vaultkeep: {}

    },
    mutations: {
        setUser(state, user) {
            state.user = user
        }

    },
    actions: {
        // will need to change router push location
        authenicate({ commit, dispatch }) {
            auth('account/authenticate', )
                .then(res => {
                    commit('setUsers', res.data.data)
                    router.push({ name: 'Main' })
                })
                .catch(() => {
                    router.push({ name: 'Main' })
                })
        }

    }
})

export default store