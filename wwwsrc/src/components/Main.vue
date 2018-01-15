<template>
  <div class="main container-fluid">
    <div class="row banner">
      <div class="col-sm-3">
        <h4>keepr.</h4>
      </div>
      <div class="col-sm-6 text-center">
        <h2>hey mang</h2>
      </div>
      <div class="col-sm-3" id="login">
        <button type="button" class="btn btn-default btn-lg" data-toggle="modal" data-target="#loginModal">Login</button>
        <div class="modal fade login" id="loginModal" tabindex="-1" role="dialog" aria-labelledby="loginModal" aria-hidden="true">
          <div class="modal-dialog">
            <div class="modal-header">
              <button type="button" class="close" data-dismiss="modal" data-backdrop="false" aria-hidden="true">&times;</button>
              <h4 style="color:black;">Login</h4>
            </div>
            <div class="modal-body">
              <div class="form" id="login" @submit.prevent="submitLogin">
                <div class="form-group">
                  <label for="email">Email</label>
                  <input class="form-control" type="email" name="email" placeholder="you@email.com" v-model='login.email' required>
                </div>
                <div class="form-group">
                  <label for="password">Password</label>
                  <input class="form-control" type="password" name="password" placeholder="password" v-model='login.password' required>
                </div>
                <div class="form-group">
                  <button type="submit">Login</button>
                </div>
              </div>
            </div>
          </div>
        </div>
      </div>
    </div>

    <h1>the beginning of my vue project</h1>

  </div>
</template>

<script>
  export default {
    name: 'Main',
    data() {
      return {
        login: {
          email: '',
          password: ''
        },
        register: {
          username: '',
          email: '',
          password: ''
        }

      }
    },
    methods: {
      submitLogin() {
        this.$store.dispatch('submitLogin', this.login)
        this.login= {
          email: '',
          password: ''
        }
      },
      submitRegister() {
        this.$store.dispatch('submitRegister', this.register)
        this.register = {
          username: '',
          email: '',
          password: ''
        }
      }
    },
    computed: {
      error() {
        return this.$store.state.error.message
      }
    }
  }
</script>

<!-- Add "scoped" attribute to limit CSS to this component only -->
<style>
  .banner {
    background-color: black;

  }
</style>