<template>
  <b-container>
    <b-row align-h="center" class="mt-5">
      <b-col cols="5">
        <b-card class="p-3">
          <h3 class="mb-4">Recover password</h3>
          <div class="mt-2" v-if="this.getMessages !== null">
            <b-alert show variant="success" v-for="(message, index) in this.getMessages" :key="index">{{message}}</b-alert>
          </div>
          <div class="mt-2" v-if="this.getErrors !== null">
            <div v-for="(error, index) in this.getErrors" :key="index">
              <b-alert show variant="danger" v-for="(message, indexMessage) in error" :key="indexMessage">{{message}}</b-alert>
            </div>
          </div>
          <b-form @submit="onSubmit">
            <b-form-group id="emailGroup"  label-for="email">
              <b-form-input id="email" type="email" v-model="form.email" required placeholder="Enter email"></b-form-input>
            </b-form-group>
            <div class="d-flex justify-content-end">
              <div>
                <b-button type="submit" variant="primary">Send E-mail</b-button>&nbsp;
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
      form: {
        email: ''
      }
    }
  },
  computed: {
    ...mapGetters(['getErrors', 'getMessages'])
  },
  created () {
    this.$store.dispatch('clearAllMessages')
    // console.log(this.getOtherErrors)
  },
  methods: {
    ...mapActions(['forgotPassword']),
    handleClick () {
      this.showDismissibleAlert = true
    },
    onSubmit (evt) {
      evt.preventDefault()
      // alert(JSON.stringify(this.form))
      this.forgotPassword(this.form)
        .then(() => {
          this.form.email = ''
        })
        .catch(() => {
          // todo show errors from vuex state
        })
    }
  }
}
</script>

