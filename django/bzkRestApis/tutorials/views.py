from django.shortcuts import render


@api_view(['GET', 'POST', 'DELETE'])
def tutorial_list(request):

@api_view(['GET', 'PUT', 'DELETE'])
def tutorial_detail(request, pk):
    try: 
        tutorial = Tutorial.objects.get(pk=pk) 
    except Tutorial.DoesNotExist: 
        return JsonResponse({'message': 'The tutorial does not exist'}, status=status.HTTP_404_NOT_FOUND) 
         
@api_view(['GET'])
def tutorial_list_published(request):
    