import Web3 from web3;
const getWeb3 = async () => {
  return new Promise(async (resolve, reject) => {
    const web3 = new Web3(window.ethereum)

    try{
      await window.ethereum.require({method: "eth_requestAccounts"})
      resolve(web3)
    }
    catch(error){
      reject(error)
    }
  })
}

(async () => {
const web3 = await getWeb3()
})();

