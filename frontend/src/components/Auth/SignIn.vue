<template>
  <b-container>
    <b-row align-h="center" class="mt-5">
      <b-col cols="5">
        <b-card class="p-3">
          <!-- <h3 class="mb-4">Login</h3> -->
          <!-- <div class="mt-2" v-if="this.getMessages !== null">
            <b-alert show variant="success" v-for="(message, index) in this.getMessages" :key="index">{{message}}</b-alert>
          </div> -->
          <div class="mt-2" v-if="this.getErrors !== null">
            <div v-for="(error, index) in this.getErrors" :key="index">
              <b-alert show variant="danger" v-for="(message, indexMessage) in error" :key="indexMessage">{{message}}</b-alert>
            </div>
          </div>
          <b-form @submit="onSubmit">
            <b-form-group id="exampleInputGroup1" label="Email address:" label-for="exampleInput1">
              <b-form-input id="exampleInput1" type="email" v-model="form.email" required placeholder="Enter email"></b-form-input>
            </b-form-group>
            <b-form-group id="exampleInputGroup2" label="Password:" label-for="exampleInput2">
              <b-form-input id="exampleInput2" type="password" v-model="form.password" required placeholder="Enter password"></b-form-input>
            </b-form-group>
            <!-- <b-form-group id="exampleGroup4">
              <b-form-checkbox-group v-model="form.checked" id="exampleChecks">
                <b-form-checkbox value="remember">Remember me</b-form-checkbox>
              </b-form-checkbox-group>
            </b-form-group> -->
            <div class="d-flex justify-content-between">
              <div>
                <b-button type="submit" variant="primary">Log In</b-button>&nbsp;
              </div>
              <div>
                <b-button to="forgot">Forgot Password</b-button>
              </div>
            </div>
          </b-form>
        </b-card>
      </b-col>
    </b-row>
  </b-container>
</template>

<script>
import {mapActions, mapGetters} from 'vuex'

export default {
  data () {
    return {
      showDismissibleAlert: false,
      form: {
        email: 'jusupovz@gmail.com',
        password: 'qweqwe'
      }
    }
  },
  computed: {
    ...mapGetters(['getErrors'])
  },
  created () {
    this.$store.dispatch('clearAllMessages')
    // console.log(this.getOtherErrors)
  },
  methods: {
    ...mapActions(['signUserIn']),
    handleClick () {
      this.showDismissibleAlert = true
    },
    onSubmit (evt) {
      evt.preventDefault()
      // alert(JSON.stringify(this.form))
      this.signUserIn(this.form)
        .then(() => this.$router.push('/'))
        .catch(() => {
          // todo show errors from vuex state
        })
    }
  }
}
</script>

