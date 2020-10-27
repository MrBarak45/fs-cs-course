(*

async { <- annotation pour block du code parllele
    
    ! -> Bang
    ! -> Marche toujours avec async
    ! -> equivalent de mot-cle await en C#
    


    let x = functionCallOrValue -> binding normal de valeur 
    let! x = functionCallOrValue -> fait un await sur le resultat pour finir
    


    use x = functionCallOrValue -> binding normal de valeur avec un ~Dispose() automatique
    use! x = functionCallOrValue -> fait un await sur le resultat pour finir avec un ~Dispose() automatique
    


    do -> appel d'une operation qui retourne Unit
    do! -> fait un await d'une operation async qui retourne Unit



    match functionCallOrValue with -> matching normal
    match! functionCallOrValue with -> fait un await sur le call async, apres ca fait le matching
    

    return -> fait un wrapping de la valeur de retour dans un Async, par ex. async {return 42} -> Async<int>
    return! -> retourne un Async sans le wrapping, par ex. async {return! functionAsync} 


}



*)
