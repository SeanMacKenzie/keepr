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
        activevault: {},
        vaultkeep: {}

    },
    mutations: {
        setUser(state, user) {
            state.user = user
        },
        handleError(state, err) {
            state.error = err
        },
        setKeeps(state, data) {
            state.keeps = data
        },
        setActiveKeep(state, data) {
            state.activekeep = data
        },
        setActiveVault(state, data) {
            state.activeVault = data
        }

    },
    actions: {
        //Auth functions
        authenticate({ commit, dispatch }) {
            auth('account/authenticate', )
                .then(res => {

                    console.log("Itdo auth", res.data)
                    commit('setUser', res.data)
                    router.push({ name: 'Main' })
                })
                .catch(() => {
                    router.push({ name: 'Main' })
                })
        },
        submitLogin({ commit, dispatch }, user) {
            auth.post('account/login', user)
                .then(res => {
                    console.log("Itdo login", res.data)
                    commit('setUser', res.data)
                    router.push({ name: 'Main' })
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#loginModal').modal('hide')
        },
        submitRegister({ commit, dispatch }, newUser) {
            auth.post('account/register', newUser)
                .then(res => {
                    commit('setUser', res.data.data)
                    router.push({ name: 'Main' })
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#loginModal').modal('hide')
        },
        logout({ commit, dispatch }) {
            auth.delete('account')
                .then(res => {
                    commit('setUser', {})
                    router.push({ name: 'Main' })
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },

        //Keeps functions
        getKeeps({ commit, dispatch }) {
            api('keeps')
                .then(res => {
                    console.log("getKeeps", res.data.data)
                    commit('setKeeps', res.data.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        getKeep({ commit, dispatch }, id) {
            api('keeps/' + id)
                .then(res => {
                    commit('setActiveKeep', res.data.data)
                })
                .catch(err => {
                    commit('handleError', err)
                })
        },
        createKeep({ commit, dispatch }, newKeep) {
            api.post('keeps/', newKeep)
                .then(res => {
                    dispatch('getKeeps')
                })
                .catch(err => {
                    commit('handleError', err)
                })
            $('#createKeepModal').modal('hide')
        },
        removeKeep({ commit, dispatch }, keep) {
            api.delete('keeps/' + keep._id)
                .then(res => {
                    dispatch('getKeeps')
                })
                .catch(err => {
                    commit('handleError', err)
                })
        }
    }
})

export default store