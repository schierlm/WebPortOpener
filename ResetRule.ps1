$ruleName="DynamicRule"
$policy = New-Object -COM "HNetCfg.FWPolicy2";
$policy.Rules.Item($ruleName).RemoteAddresses="127.0.0.127";
